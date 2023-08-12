using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnthusiaVolumeFS.FileGroups
{
    public class FileGroup_tutorial : BaseFileGroup
    {
        public override bool GetArcEnable(int fileIndex)
        {
            return true;
        }

        public override int GetDevice(int fileIndex)
        {
            // They're all 3
            return 3;
        }

        public override string GetFileName(int fileIndex)
        {
            return $"tutorial{fileIndex:D3}.bin";
        }

        public override int GetPathKey(int fileIndex)
        {
            return 0x3C;
        }

        public override int GetSize()
        {
            return 0x64;
        }
    }
}
