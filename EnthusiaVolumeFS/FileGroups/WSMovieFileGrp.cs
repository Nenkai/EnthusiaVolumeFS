using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnthusiaVolumeFS.FileGroups
{
    public class WSMovieFileGrp : BaseFileGroup
    {
        public static string Name => nameof(WSMovieFileGrp);

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
            if (fileIndex < 0x0A)
                return $"movie{fileIndex:D2}.enc";
            else
                return $"ipu{fileIndex:D2}.enc";
        }

        public override int GetPathKey(GameType type, int fileIndex)
        {
            return 0x28;
        }

        public override int GetSize(GameType type)
        {
            return 0x1E;
        }
    }
}
