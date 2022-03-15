using System;
using System.Globalization;
using System.Linq;

namespace Lecture3 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main2(string[] args)
        {

        }


    }

    internal class customProgram
    {
        public static void printSomething()
        {
            Console.WriteLine("this is internal method");
        }
    }

    public class publicClass
    {
        public static void printSomething()
        {
            Console.WriteLine("this is public class method");
        }
    }

    class subPrivate
    {
        public static void test2()
        {
            customProgram.printSomething();
        }

    }




}