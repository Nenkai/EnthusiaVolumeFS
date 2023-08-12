using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnthusiaVolumeFS.Data;

namespace EnthusiaVolumeFS.FileGroups
{
    public class TeMakerLogoPkdtFileGroup : BaseFileGroup
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
            int combinedCode = MakerList.GetCombinedCodeFromCarIndex(fileIndex);
            return $"{combinedCode:D5}_{0:D2}.sel";
        }

        public override int GetPathKey(int fileIndex)
        {
            return 12;
        }

        public override int GetSize()
        {
            return MakerList.UnkCount * 1;
        }
    }
}
