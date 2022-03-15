using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lecture_3
{
    internal class staticMethods
    {
        public static void printStudentsWithFor(List<lecture_1503.student> lstStudents)
        {
            for (int i = 0; i < lstStudents.Count; i++)
            {
                Console.WriteLine($"index:{i} age: \t{lstStudents[i].studentAge}");
            }
        }

        public static void printStudentsWithForEach(List<lecture_1503.student> lstStudents)
        {
            int i = 0;
            foreach (lecture_1503.student vrStudent in lstStudents)
            {
                Console.WriteLine($"index:{i} age: \t{lstStudents[i].studentAge}");
                i++;
            }
            i = 0;
            foreach (var vrStudent in lstStudents)
            {
                Console.WriteLine($"index:{i} age: \t{lstStudents[i].studentAge}");
                i++;
            }
        }
    }
}
