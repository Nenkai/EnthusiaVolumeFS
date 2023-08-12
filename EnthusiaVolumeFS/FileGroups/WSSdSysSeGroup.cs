using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnthusiaVolumeFS.FileGroups
{
    public class WSSdSysSeGroup : BaseFileGroup
    {
        public static string Name => nameof(WSSdSysSeGroup);

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
            return $"sysse{fileIndex:D3}.bin";
        }

        public override int GetPathKey(GameType type, int fileIndex)
        {
            return 0x27;
        }

        public override int GetSize(GameType type)
        {
            return 1;
        }
    }
}
