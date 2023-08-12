using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnthusiaVolumeFS.Data;

namespace EnthusiaVolumeFS.FileGroups
{
    public class TeFgrpSelCarPack : BaseFileGroup
    {
        public static string Name => nameof(TeFgrpSelCarPack);

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
            return $"{carCode:D8}.car";
        }

        public override int GetPathKey(GameType type, int fileIndex)
        {
            return 7;
        }

        public override int GetSize(GameType type)
        {
            return 0xDE;
        }
    }
}
