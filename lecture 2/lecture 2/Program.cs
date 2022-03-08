using System;

namespace Lecture2 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public long sumTwoNumbers_nonStatic(long number1, long number2)
        {
            return number1 + number2;
        }

        public static long sumTwoNumbers_Static(long number1, long number2)
        {
            return number1 + number2;
        }
    }

    public static class exClass1
    {
        public static void doStuff()
        {
            //Program.sumTwoNumbers_nonStatic(32,11);//to fix this we need to change like below
            Program myProgram = new Program();
            myProgram.sumTwoNumbers_nonStatic(32, 11);

            Program.sumTwoNumbers_Static(32, 11);
        }
    }
}