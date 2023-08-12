using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnthusiaVolumeFS.FileGroups
{
    public class TeCrsStatSmallPkdtFileGroup : BaseFileGroup
    {
        public static string Name => nameof(TeCrsStatSmallPkdtFileGroup);

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
            return $"{fileIndex:D3}_{0:D2}.sel";
        }

        public override int GetPathKey(GameType type, int fileIndex)
        {
            return 19;
        }

        public override int GetSize(GameType type)
        {
            return 0x0C * 1;
        }
    }
}
