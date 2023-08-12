using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnthusiaVolumeFS.FileGroups
{
    public class TeDataMngFileGroup : BaseFileGroup
    {
        public override bool GetArcEnable(int fileIndex)
        {
            return false;
        }

        public override int GetDevice(int fileIndex)
        {
            // They're all 3
            return 3;
        }

        public override string GetFileName(int fileIndex)
        {
            return fileIndex switch
            {
                0 => "d000.bin",
                1 => "d001.bin",
            };
        }

        public override int GetPathKey(int fileIndex)
        {
            return fileIndex switch
            {
                0 => 0,
                1 => 0,
            };
        }

        public override int GetSize()
        {
            return 2;
        }
    }
}
