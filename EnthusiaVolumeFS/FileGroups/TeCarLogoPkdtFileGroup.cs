using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnthusiaVolumeFS.Data;

namespace EnthusiaVolumeFS.FileGroups
{
    public class TeCarLogoPkdtFileGroup : BaseFileGroup
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
            int carCode = CarList.IndexToCourseCode(fileIndex);
            return $"{carCode:D3}_{0:D2}.sel";
        }

        public override int GetPathKey(int fileIndex)
        {
            return 11;
        }

        public override int GetSize()
        {
            return 0xD3 * 1;
        }
    }
}
