using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnthusiaVolumeFS.Data;

namespace EnthusiaVolumeFS.FileGroups
{
    public class TeFgrpMapPack : BaseFileGroup
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
            int courseCode = CourseList.Courses[fileIndex].CourseCode;
            return $"{courseCode:D3}_00.map";
        }

        public override int GetPathKey(int fileIndex)
        {
            return 5;
        }

        public override int GetSize()
        {
            return 0xC8;
        }
    }
}
