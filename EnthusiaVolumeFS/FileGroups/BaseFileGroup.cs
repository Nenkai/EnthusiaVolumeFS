using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnthusiaVolumeFS.FileGroups
{
    public abstract class BaseFileGroup
    {
        public abstract int GetSize(GameType type);
        public abstract int GetPathKey(GameType type, int fileIndex);
        public abstract string GetFileName(GameType type, int fileIndex);
        public abstract int GetDevice(int fileIndex);
        public abstract bool GetArcEnable(int fileIndex);

    }
}
