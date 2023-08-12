using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Buffers;

using Syroot.BinaryData;

using EnthusiaVolumeFS.FileGroups;

namespace EnthusiaVolumeFS
{
    public class VolumeManager
    {
        public const int SectorSize = 0x800;

        private int[] entryOffsets;
        private BinaryStream _dataStream;

        public int _fileCount { get; set; }
        private GameType Type { get; set; }

        public Dictionary<string, BaseFileGroup> NameToGroup = new Dictionary<string, BaseFileGroup>()
        {
            { WSMovieFileGrp.Name, new WSMovieFileGrp() },
            { WSBgmFileGrp.Name, new WSBgmFileGrp() },
            { IRXFileGroup.Name, new IRXFileGroup() },
            { WSSdSysSeGroup.Name, new WSSdSysSeGroup() },
            { WSSdOptCarSeGroup.Name, new WSSdOptCarSeGroup() },
            { mynFgrpEtc.Name, new mynFgrpEtc() },
            { TeEtcFileGroup.Name, new TeEtcFileGroup() },
            { okFileGroup.Name, new okFileGroup() },
            { WSSdAmbSeGroup.Name, new WSSdAmbSeGroup() },
            { WSSdCarSeGroup.Name, new WSSdCarSeGroup() },
            { WSSdSqealSeGroup.Name, new WSSdSqealSeGroup() },
            { TeFgrpMapPack.Name, new TeFgrpMapPack() },
            { TeFgrpCarPack.Name, new TeFgrpCarPack() },
            { TeFgrpSelCarPack.Name, new TeFgrpSelCarPack() },

            // pkdt (data type?) linked to those "Ryu" stuff
            { TeSelPkdtFileGroup.Name, new TeSelPkdtFileGroup()}, // Path key 0x2A?
            { TeBgImagePkdtFileGroup.Name, new TeBgImagePkdtFileGroup()}, // Path key 0x2B?
            { TeCarIconPkdtFileGroup.Name, new TeCarIconPkdtFileGroup()}, // Path Key 0x2C?
            { TeCarLogoPkdtFileGroup.Name, new TeCarLogoPkdtFileGroup()}, // Path Key 0x2D?
            { TeMakerLogoPkdtFileGroup.Name, new TeMakerLogoPkdtFileGroup()}, // Path Key 0x2E?
            { TeMakerIconPkdtFileGroup.Name, new TeMakerIconPkdtFileGroup()}, // Path Key 0x2F?
            { TeCrsSnapImagePkdtFileGroup.Name, new TeCrsSnapImagePkdtFileGroup()}, // Path Key 0x30?
            { TeCrsSnapIconPkdtFileGroup.Name, new TeCrsSnapIconPkdtFileGroup()}, // Path Key 0x31?
            { TeMiniMapSelPkdtFileGroup.Name, new TeMiniMapSelPkdtFileGroup()}, // Path Key 0x32?
            { TeMiniMapRacePkdtFileGroup.Name, new TeMiniMapRacePkdtFileGroup()}, // Path Key 0x33?
            { TeCrsStatBigPkdtFileGroup.Name, new TeCrsStatBigPkdtFileGroup()}, // Path Key 0x34?
            { TeCrsStatSmallPkdtFileGroup.Name, new TeCrsStatSmallPkdtFileGroup()}, // Path Key 0x35?
           
            { FileGroup_tutorial.Name, new FileGroup_tutorial() },
            { TeDataMngFileGroup.Name, new TeDataMngFileGroup() },
            { TeFileMngFileGroup.Name, new TeFileMngFileGroup() },
            { Ts_FileGroup_replay.Name, new Ts_FileGroup_replay() },
            { Ts_recordFileGroup.Name, new Ts_recordFileGroup() },
        };

        public List<BaseFileGroup> BaseFileGroups = new List<BaseFileGroup>();

        public void Open(GameType type, string file)
        {
            Type = type;

            InitGroups(type);
            
            if (string.IsNullOrEmpty(file))
                throw new ArgumentException("Bad file name.");

            if (!File.Exists(file))
                throw new FileNotFoundException("Volume toc file provided not found.");

            using var fs = new FileStream(file, FileMode.Open);
            using var bs = new BinaryStream(fs, ByteConverter.Little);

            _fileCount = (int)fs.Length / sizeof(int);
            entryOffsets = bs.ReadInt32s(_fileCount);

            string dir = Path.GetDirectoryName(file);
            string dataFile = Path.Combine(dir, "d001.bin");

            if (!File.Exists(dataFile))
                throw new FileNotFoundException("d001.bin (data file) is missing.");

            var fs2 = new FileStream(dataFile, FileMode.Open);
            _dataStream = new BinaryStream(fs2, ByteConverter.Little);
        }

        public void InitGroups(GameType type)
        {
            var lines = File.ReadAllLines($"Data/{type}/GroupOrder.txt");
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line) || line.StartsWith("//"))
                    continue;

                BaseFileGroups.Add(NameToGroup[line]);
            }
        }

        public void UnpackAll(string outputDir)
        {
            for (var i = 0; i < _fileCount; i++)
                UnpackFile(i, outputDir);

            Console.WriteLine("Done.");
        }

        public void UnpackFile(int fileIndex, string outputDir)
        {
            BaseFileGroup targetGroup = null;
            int fileGroupIndex = fileIndex;
            foreach (var group in BaseFileGroups)
            {
                int sizeInGroup = group.GetSize(Type);
                if (fileGroupIndex < sizeInGroup)
                {
                    targetGroup = group;
                    break;
                }

                fileGroupIndex -= sizeInGroup;
            }

            if (targetGroup is null)
                return;

            string fileName = targetGroup.GetFileName(Type, fileGroupIndex);
            int pathKey = targetGroup.GetPathKey(Type, fileGroupIndex);
            var pathKeyEntry = PathKeyEntries.List[pathKey];
            string outputFilePath = Path.Combine(pathKeyEntry.name, fileName);

            int fileSectorSize;
            if (fileIndex + 1 >= entryOffsets.Length)
                fileSectorSize = (int)(_dataStream.Length / SectorSize) - entryOffsets[fileIndex];
            else
                fileSectorSize = entryOffsets[fileIndex + 1] - entryOffsets[fileIndex];

            ulong fileSize = (ulong)fileSectorSize * (ulong)SectorSize;
            ulong fileOffset = (ulong)entryOffsets[fileIndex] * SectorSize;

            if (fileSize == 0)
            {
                Console.WriteLine($"Skipping {outputFilePath}, file is empty ({fileIndex})");
                return;
            }

            outputDir = Path.GetFullPath(outputDir);
            string relativeDir = Path.GetDirectoryName(outputFilePath);

            string fullDir = Path.Combine(outputDir, relativeDir);
            Directory.CreateDirectory(fullDir);

            string fullPath = Path.Combine(outputDir, outputFilePath);

            using var output = File.Create(fullPath);
            byte[] buffer = ArrayPool<byte>.Shared.Rent(0x20000);
            _dataStream.Position = (long)fileOffset;

            while (fileSize > 0)
            {
                ulong cnt = Math.Min(fileSize, 0x20000);
                _dataStream.Read(buffer, 0, (int)cnt);
                output.Write(buffer, 0, (int)cnt);

                fileSize -= cnt;
            }

            ArrayPool<byte>.Shared.Return(buffer);

            Console.WriteLine($"Extracted: {outputFilePath} ({fileIndex})");
        }
    }
}
