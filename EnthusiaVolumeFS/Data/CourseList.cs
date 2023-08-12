using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EnthusiaVolumeFS.Data
{
    public class CourseList
    {
        public const int Count = 200;

        public static List<Course> Courses = new List<Course>();

        static CourseList()
        {
            string[] lines = File.ReadAllLines("Data/CourseList.txt");
            foreach (var line in lines)
            {
                if (line.StartsWith("//") || string.IsNullOrEmpty(line))
                    continue;

                string[] spl = line.Split("|");
                var course = new Course();
                course.CourseCode = int.Parse(spl[0]);
                course.NameAlphabet = spl[1];
                Courses.Add(course);
            }
        }

    }

    public class Course
    {
        public int CourseCode { get; set; }
        public string NameAlphabet { get; set; }
    }


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
