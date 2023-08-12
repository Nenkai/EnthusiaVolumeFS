using Syroot.BinaryData;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnthusiaVolumeFS
{
    public class PackageExtractor
    {
        public static bool Extract(string path)
        {
            using var fs = new FileStream(path, FileMode.Open);
            using var bs = new BinaryStream(fs);

            if (bs.ReadUInt16() != 0xFC87)
                return false;

            bs.ReadInt16(); // Unk
            bs.ReadInt32(); // Unk 2

            int fileCount = bs.ReadInt32();
            for (var i = 0; i < fileCount; i++)
            {
                bs.Position = 0x0C + (i * 0x08);
                int offset = bs.ReadInt32();
                int length = bs.ReadInt32();

                bs.Position = offset;
                byte[] fileData = bs.ReadBytes(length);

                Directory.CreateDirectory(path + "_extracted");
                File.WriteAllBytes($"{path}_extracted/{i}.bin", fileData);
            }

            return true;
        }
    }
}
