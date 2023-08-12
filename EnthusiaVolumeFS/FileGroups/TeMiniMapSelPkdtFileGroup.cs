using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnthusiaVolumeFS.FileGroups
{
    public class TeMiniMapSelPkdtFileGroup : BaseFileGroup
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
            return $"{fileIndex:D3}_{0:D2}.sel";
        }

        public override int GetPathKey(int fileIndex)
        {
            return 16;
        }

        public override int GetSize()
        {
            return 0x140 * 1;
        }
    }
}
