using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnthusiaVolumeFS.FileGroups
{
    public class mynFgrpEtc : BaseFileGroup
    {
        public static string Name => nameof(mynFgrpEtc);

        public override bool GetArcEnable(int fileIndex)
        {
            return true;
        }

        public override int GetDevice(int fileIndex)
        {
            return 3;
        }

        public override string GetFileName(GameType type, int fileIndex)
        {
            return $"el_race_data.rcd";
        }

        public override int GetPathKey(GameType type, int fileIndex)
        {
            return 0x40;
        }

        public override int GetSize(GameType type)
        {
            return 1;
        }
    }
}
