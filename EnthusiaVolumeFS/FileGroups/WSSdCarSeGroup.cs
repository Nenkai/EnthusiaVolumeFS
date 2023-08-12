using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnthusiaVolumeFS.Data;

namespace EnthusiaVolumeFS.FileGroups
{
    public class WSSdCarSeGroup : BaseFileGroup
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
            int unk = CarList.IndexToCourseCode(fileIndex / 4);
            return $"{unk:X8}_{fileIndex & 3:D1}.edp";
        }

        public override int GetPathKey(int fileIndex)
        {
            return 0x27;
        }

        public override int GetSize()
        {
            return 0x370;
        }

    }
}
