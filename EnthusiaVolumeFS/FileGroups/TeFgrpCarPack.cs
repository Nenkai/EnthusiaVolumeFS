using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnthusiaVolumeFS.Data;

namespace EnthusiaVolumeFS.FileGroups
{
    public class TeFgrpCarPack : BaseFileGroup
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
            return $"{carCode:X8}.car";
        }

        public override int GetPathKey(int fileIndex)
        {
            return 6;
        }

        public override int GetSize()
        {
            return 0xDE;
        }
    }
}
