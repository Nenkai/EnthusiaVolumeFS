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
        public static string Name => nameof(WSSdCarSeGroup);

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
            int carCode = CarList.IndexToCarCode(fileIndex / 4);
            return $"{carCode:D8}_{fileIndex & 3:D1}.edp";
        }

        public override int GetPathKey(GameType type, int fileIndex)
        {
            return 0x27;
        }

        public override int GetSize(GameType type)
        {
            return 0x370;
        }

    }
}
