
using Syroot.BinaryData;

namespace EnthusiaVolumeFS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-- EnthusiaVolumeFS by Nenkai --");
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: <path_to_d000.bin or 0xFC87 pack file> <output_directory>");
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

            var volume = new VolumeManager();
            volume.Open(args[0]);
            volume.UnpackAll(args[1]);
        }
    }
}