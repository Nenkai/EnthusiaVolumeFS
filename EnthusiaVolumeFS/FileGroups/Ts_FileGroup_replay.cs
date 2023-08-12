using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnthusiaVolumeFS.FileGroups
{
    public class Ts_FileGroup_replay : BaseFileGroup
    {
        public override bool GetArcEnable(int fileIndex)
        {
            return true;
        }

        public override int GetDevice(int fileIndex)
        {
            return 3;
        }

        public override string GetFileName(int fileIndex)
        {
            return $"rpl{fileIndex:D3}.rpl";
        }

        public override int GetPathKey(int fileIndex)
        {
            return 0x3A;
        }

        public override int GetSize()
        {
            return 0x63;
        }
    }
}
