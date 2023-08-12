using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnthusiaVolumeFS.FileGroups
{
    public abstract class BaseFileGroup
    {
        public abstract int GetSize();
        public abstract int GetPathKey(int fileIndex);
        public abstract string GetFileName(int fileIndex);
        public abstract int GetDevice(int fileIndex);
        public abstract bool GetArcEnable(int fileIndex);

    }
}
