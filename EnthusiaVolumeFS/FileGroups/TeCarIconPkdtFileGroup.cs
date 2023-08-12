using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnthusiaVolumeFS.Data;

namespace EnthusiaVolumeFS.FileGroups
{
    public class TeCarIconPkdtFileGroup : BaseFileGroup
    {
        public static string Name => nameof(TeCarIconPkdtFileGroup);

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
            int carCode = CarList.IndexToCarCode(fileIndex);
            return $"{carCode:D3}_{0:D2}.sel";
        }

        public override int GetPathKey(GameType type, int fileIndex)
        {
            return 10;
        }

        public override int GetSize(GameType type)
        {
            return 0xD3 * 1;
        }
    }
}
