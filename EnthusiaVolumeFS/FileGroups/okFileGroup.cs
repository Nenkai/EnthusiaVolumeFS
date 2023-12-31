﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnthusiaVolumeFS.FileGroups
{
    public class okFileGroup : BaseFileGroup
    {
        public static string Name => nameof(okFileGroup);

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
                0 => "system.ico",
                1 => "replay.ico",
            };
        }

        public override int GetPathKey(GameType type, int fileIndex)
        {
            return fileIndex switch
            {
                0 => 0x3D,
                1 => 0x3D,
            };
        }

        public override int GetSize(GameType type)
        {
            return 2;
        }
    }
}
