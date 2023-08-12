using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnthusiaVolumeFS.FileGroups
{
    public class Ts_FileGroup_replay : BaseFileGroup
    {
        public static string Name => nameof(Ts_FileGroup_replay);

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
            return $"rpl{fileIndex:D3}.rpl";
        }

        public override int GetPathKey(GameType type, int fileIndex)
        {
            return 0x3A;
        }

        public override int GetSize(GameType type)
        {
            return 0x63;
        }
    }
}
