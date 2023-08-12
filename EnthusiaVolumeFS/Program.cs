
using EnthusiaVolumeFS.Data;

using Syroot.BinaryData;

using System;

namespace EnthusiaVolumeFS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-- EnthusiaVolumeFS by Nenkai --");
            if (args.Length != 3)
            {
                Console.WriteLine("Usage: <path_to_d000.bin or 0xFC87 pack file> <output_directory> <game_type>");
                Console.WriteLine($"Valid game types: {string.Join(", ", ((GameType[])Enum.GetValues(typeof(GameType))).Select(e => e.ToString()))}");
                return;
            }

            if (!File.Exists(args[0]))
            {
                Console.WriteLine("Error: provided file does not exist");
                return;
            }

            if (PackageExtractor.Extract(args[0]))
            {
                Console.WriteLine($"Extracted package {args[0]}");
                return;
            }

            if (!Enum.TryParse(args[2], out GameType type))
            {
                Console.WriteLine($"Error: Invalid game type");
                return;
            }

            MakerList.InitCarToMakerVarCount(type);

            var volume = new VolumeManager();
            volume.Open(type, args[0]);
            volume.UnpackAll(args[1]);
        }
    }
}