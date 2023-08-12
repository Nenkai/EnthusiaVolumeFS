using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EnthusiaVolumeFS.Data
{
    public class MakerList
    {
        public const int HighestID = 57;
        public static Maker[] Makers = new Maker[HighestID];
        public static int[] CarsPerMaker = new int[HighestID];
        public static int UnkCount { get; set; }

        static MakerList()
        {
            string[] lines = File.ReadAllLines("Data/MakerList.txt");
            foreach (var line in lines)
            {
                if (line.StartsWith("//") || string.IsNullOrEmpty(line))
                    continue;

                string[] spl = line.Split("|");
                var maker = new Maker();
                maker.MakerCode = int.Parse(spl[0]);
                maker.Unk = int.Parse(spl[1]);
                maker.NameJP = spl[2];
                maker.NameAlphabet = spl[3];
                Makers[maker.MakerCode] = maker;
            }
        }

        public static void InitCarToMakerVarCount(GameType type)
        {
            string[] lines = File.ReadAllLines($"Data/{type}/CarToMakerVarCount.txt");
            foreach (var line in lines)
            {
                if (line.StartsWith("//") || string.IsNullOrEmpty(line))
                    continue;

                string[] spl = line.Split("|");
                int car = int.Parse(spl[0]);
                int maker = int.Parse(spl[1]);
                int unkCount = int.Parse(spl[2]);

                if (unkCount >= CarsPerMaker[maker])
                    CarsPerMaker[maker] = unkCount + 1;
            }

            for (var i = 0; i < HighestID; i++)
                UnkCount += CarsPerMaker[i];
        }

        public static int GetCombinedCodeFromCarIndex(int carIndex)
        {
            GetTunerAndSubCarIndex(carIndex, out int tunerIndex, out int carNumberIndex);
            return GetCombinedIndex(tunerIndex, carNumberIndex);
        }

        public static void GetTunerAndSubCarIndex(int index, out int tunerIndex, out int carNumberIndex)
        {
            int i;
            for (i = 0; i < HighestID; i++)
            {
                if (index < CarsPerMaker[i])
                    break;

                index -= CarsPerMaker[i];
            }

            tunerIndex = i;
            carNumberIndex = index;
        }

        public static int GetCombinedIndex(int tunerIndex, int carNumberIndex)
        {
            return tunerIndex * 100 + carNumberIndex;
        }
    }

    public class Maker
    {
        public int MakerCode { get; set; }
        public int Unk { get; set; }
        public string NameAlphabet { get; set; }
        public string NameJP { get; set; }
    }

    /* IDC for maker list
      * auto i;
        auto ea = 0x48fc90;
    
        for (i = 0; i < 46; i++)
        {
            auto car_code = get_dword(ea);
            auto unk = get_dword(ea + 0x04);
            auto nameJpPtr = get_dword(ea + 0x08);
            auto nameAlphPtr = get_dword(ea + 0x0C);
    
            auto nameJp = get_strlit_contents(nameJpPtr, -1, STRTYPE_C);
            auto nameAlph = get_strlit_contents(nameAlphPtr, -1, STRTYPE_C);
            Message("%d|%d|%s|%s\n", car_code, unk, nameJp, nameAlph);
    
            ea =  ea + 0x10;
        }
     */

    /* IDC for car to maker
     * auto i;
       auto ea = 0x49b370;
    
       for (i = 0; i < 211; i++)
       {
           auto car_code = word(ea);
           auto tuner_code = byte(ea + 0x02);
           auto unk = byte(ea + 0x03);
           Message("%d|%d|%d\n", car_code, tuner_code, unk);
    
           ea =  ea + 0x04;
       }
    */


}
