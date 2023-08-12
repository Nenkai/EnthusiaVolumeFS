using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnthusiaVolumeFS.FileGroups
{
    public class Ts_recordFileGroup : BaseFileGroup
    {
        public override bool GetArcEnable(int fileIndex)
        {
            return true;
        }

        public override int GetDevice(int fileIndex)
        {
            return 3;
        }

        public override string GetFileName(int fileIndex)
        {
            return fileIndex switch
            {
                0 => "timeatt0.rcd",
                1 => "tutoria0.rcd",
                2 => "challen0.rcd",
                3 => "freerac0.rcd",
                4 => "racelif0.rcd",
            };
        }

        public override int GetPathKey(int fileIndex)
        {
            return 0x3B;
        }

        public override int GetSize()
        {
            return 5;
        }
    }
}
