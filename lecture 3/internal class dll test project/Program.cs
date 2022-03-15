
using Lecture3;

namespace internalClassDllTest // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lecture3.publicClass.printSomething();

            //Lecture3.customProgram.printSomething(); this wont work because it is internal
        }


    }

}