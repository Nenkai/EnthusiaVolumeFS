using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnthusiaVolumeFS.FileGroups
{
    public class TeEtcFileGroup : BaseFileGroup
    {
        public static string Name => nameof(TeEtcFileGroup);

        public override bool GetArcEnable(int fileIndex)
        {
            return true;
        }

        public override int GetDevice(int fileIndex)
        {
            // They're all 3
            return 3;
        }

        public override string GetFileName(GameType type, int fileIndex)
        {
            return fileIndex switch
            {
                0 => "pvram_000_e.bin",
                1 => "pvram_001_e.bin",
                2 => "fontB.tm2",
                3 => "fontdic.kbi.gs",
                4 => "ef_cmn.ef",
                5 => "all_cbd.bin",
                6 => "all_icd.bin",
                7 => "shashu_x_course.bin",
                8 => "099_00/mesh.vgs",
            };
        }

        public override int GetPathKey(GameType type, int fileIndex)
        {
            return fileIndex switch
            {
                0 => 1,
                1 => 1,
                2 => 0x38,
                3 => 0x38,
                4 => 0x26,
                5 => 0x14,
                6 => 0x14,
                7 => 0x14,
                8 => 0x16,
            };
        }

        public override int GetSize(GameType type)
        {
            return 9;
        }
    }
}
