using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnthusiaVolumeFS.FileGroups
{
    public class WSSdOptCarSeGroup : BaseFileGroup
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
            return $"stayse{fileIndex:D3}.bin";
        }

        public override int GetPathKey(int fileIndex)
        {
            return 0x27;
        }

        public override int GetSize()
        {
            return 1;
        }
    }
}
