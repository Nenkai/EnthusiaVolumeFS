using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnthusiaVolumeFS.FileGroups
{
    public class mynFgrpEtc : BaseFileGroup
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
            return $"el_race_data.rcd";
        }

        public override int GetPathKey(int fileIndex)
        {
            return 0x40;
        }

        public override int GetSize()
        {
            return 1;
        }
    }
}
