using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnthusiaVolumeFS.FileGroups
{
    public class TeFileMngFileGroup : BaseFileGroup
    {
        public override bool GetArcEnable(int fileIndex)
        {
            return false;
        }

        public override int GetDevice(int fileIndex)
        {
            return 0;
        }

        public override string GetFileName(int fileIndex)
        {
            return fileIndex switch
            {
                0 => "archivelist.log",
                1 => "writecdvd.txt",
            };
        }

        public override int GetPathKey(int fileIndex)
        {
            return fileIndex switch
            {
                0 => 0,
                1 => 0,
            };
        }

        public override int GetSize()
        {
            return 2;
        }
    }
}
