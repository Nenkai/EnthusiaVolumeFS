using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnthusiaVolumeFS.FileGroups
{
    public class IRXFileGroup : BaseFileGroup
    {
        public static string Name => nameof(IRXFileGroup);

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
            return "stub";
        }

        public override int GetPathKey(GameType type, int fileIndex)
        {
            return 0x28;
        }

        public override int GetSize(GameType type)
        {
            if (type == GameType.SLUS_20967 || type == GameType.SLPM_68519)
                return 8;
            else
                return 10;
        }
    }
}
