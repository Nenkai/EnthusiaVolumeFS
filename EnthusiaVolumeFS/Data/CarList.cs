using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EnthusiaVolumeFS.Data
{
    public class CarList
    {
        public static List<Car> Cars = new List<Car>();

        static CarList()
        {
            string[] lines = File.ReadAllLines("Data/CarList.txt");
            foreach (var line in lines)
            {
                string[] spl = line.Split("|");
                var car = new Car();
                car.CarCode = int.Parse(spl[0]);
                car.Unk = int.Parse(spl[1]);
                car.NameJP = spl[2];
                car.NameAlphabet = spl[3];
                Cars.Add(car);
            }
        }

        public const int CarCount = 211;

        public static int IndexToCourseCode(int carIndex)
        {
            if (carIndex < CarCount)
                return Cars[carIndex].CarCode;
            if (carIndex >= CarCount)
                return carIndex + 0x1312C23;
            return carIndex + 0x9895AD;
        }
    }

    public class Car
    {
        public int CarCode { get; set; }
        public int Unk { get; set; }
        public string NameAlphabet { get; set; }
        public string NameJP { get; set; }
    }

    /* IDC for car list
     * auto i;
       auto ea = 0x492318;
       
       for (i = 0; i < 211; i++)
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

    /* IDC for course list
     * 
        auto i;
        auto ea = 0x382848;
        auto ea2 = 0x48a188;
    
        for (i = 0; i < 73; i++)
        {
            auto nameAlphPtr = get_dword(ea);
    
            auto nameAlph = get_strlit_contents(nameAlphPtr, -1, STRTYPE_C);
            auto crsId = word(ea2);
            Message("%d|%s\n",crsId, nameAlph);
    
            ea =  ea + 0x04;
            ea2 = ea2 + 0x02;
        }
    */


}
