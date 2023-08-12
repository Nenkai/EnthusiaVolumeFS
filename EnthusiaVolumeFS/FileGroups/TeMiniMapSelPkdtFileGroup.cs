using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnthusiaVolumeFS.FileGroups
{
    public class TeMiniMapSelPkdtFileGroup : BaseFileGroup
    {
        public static string Name => nameof(TeMiniMapSelPkdtFileGroup);

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
            return 16;
        }

        public override int GetSize(GameType type)
        {
            return 0x140 * 1;
        }
    }
}
