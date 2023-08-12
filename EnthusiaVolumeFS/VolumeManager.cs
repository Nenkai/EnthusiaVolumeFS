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
        public const int FileCount = 4079;
        public const int SectorSize = 0x800;

        private int[] entryOffsets;
        private BinaryStream _dataStream;

        public List<BaseFileGroup> BaseFileGroups = new List<BaseFileGroup>()
        {
            new WSMovieFileGrp(),
            new WSBgmFileGrp(),
            new IRXFileGroup(),
            new WSSdSysSeGroup(),
            new WSSdOptCarSeGroup(),
            new mynFgrpEtc(),
            new TeEtcFileGroup(),
            new okFileGroup(),
            new WSSdAmbSeGroup(),
            new WSSdCarSeGroup(),
            new WSSdSqealSeGroup(),
            new TeFgrpMapPack(),
            new TeFgrpCarPack(),
            new TeFgrpSelCarPack(),

            // pkdt (data type?) linked to those "Ryu" stuff
            new TeSelPkdtFileGroup(), // Path key 0x2A?
            new TeBgImagePkdtFileGroup(), // Path key 0x2B?
            new TeCarIconPkdtFileGroup(), // Path Key 0x2C?
            new TeCarLogoPkdtFileGroup(), // Path Key 0x2D?
            new TeMakerLogoPkdtFileGroup(), // Path Key 0x2E?
            new TeMakerIconPkdtFileGroup(), // Path Key 0x2F?
            new TeCrsSnapImagePkdtFileGroup(), // Path Key 0x30?
            new TeCrsSnapIconPkdtFileGroup(), // Path Key 0x31?
            new TeMiniMapSelPkdtFileGroup(), // Path Key 0x32?
            new TeMiniMapRacePkdtFileGroup(), // Path Key 0x33?
            new TeCrsStatBigPkdtFileGroup(), // Path Key 0x34?
            new TeCrsStatSmallPkdtFileGroup(), // Path Key 0x35?

            new FileGroup_tutorial(),
            new TeDataMngFileGroup(),
            new TeFileMngFileGroup(),
            new Ts_FileGroup_replay(),
            new Ts_recordFileGroup(),
        };

        public void Open(string file)
        {
            if (string.IsNullOrEmpty(file))
                throw new ArgumentException("Bad file name.");

            if (!File.Exists(file))
                throw new FileNotFoundException("Volume toc file provided not found.");

            using var fs = new FileStream(file, FileMode.Open);
            using var bs = new BinaryStream(fs, ByteConverter.Little);

            entryOffsets = bs.ReadInt32s(FileCount);

            string dir = Path.GetDirectoryName(file);
            string dataFile = Path.Combine(dir, "d001.bin");

            if (!File.Exists(dataFile))
                throw new FileNotFoundException("d001.bin (data file) is missing.");

            var fs2 = new FileStream(dataFile, FileMode.Open);
            _dataStream = new BinaryStream(fs2, ByteConverter.Little);
        }

        public void UnpackAll(string outputDir)
        {
            for (var i = 0; i < FileCount; i++)
                UnpackFile(i, outputDir);

            Console.WriteLine("Done.");
        }

        public void UnpackFile(int fileIndex, string outputDir)
        {
            BaseFileGroup targetGroup = null;
            int fileGroupIndex = fileIndex;
            foreach (var group in BaseFileGroups)
            {
                int sizeInGroup = group.GetSize();
                if (fileGroupIndex < sizeInGroup)
                {
                    targetGroup = group;
                    break;
                }

                fileGroupIndex -= sizeInGroup;
            }

            if (targetGroup is null)
                return;

            string fileName = targetGroup.GetFileName(fileGroupIndex);
            int pathKey = targetGroup.GetPathKey(fileGroupIndex);
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
