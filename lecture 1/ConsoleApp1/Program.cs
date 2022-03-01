using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("There are {2} brands and this car brand is {0}, price is {1} USD, brand was {0}, car weight is {3} kg", "BMV", 50000, 52, 2500.ToString("N0"));
            Console.Write("a ");
            Console.Write("b ");
            Console.WriteLine();
            Console.Write(Environment.NewLine);
            Console.Write("\n");
            Console.Write("\r\n");
            Console.WriteLine(3243511.3415.ToString("N2"));//3,243,511.34

            Program myProgram = new Program();
            int irResult = myProgram.sumNumbers(32, 11);
            Console.WriteLine(irResult);

            sumNumbers2(11, 22);

            secondClass.doSomething();

            Console.WriteLine(secondClass.sr2);
        }

        private int sumNumbers(int ir1, int ir2)
        {
            return ir1 + ir2;
        }

        private static int sumNumbers2(int ir1, int ir2)
        {
            return ir1 + ir2;
        }

        public static int sumNumbers3(int ir1, int ir2)
        {
            return ir1 + ir2;
        }

        public int sumNumbers4(int ir1, int ir2)
        {
            return ir1 + ir2;
        }
    }

    public static class secondClass
    {
        private static string sr1 = "test 1";
        public static string sr2 = "test 2";
        private static string sr3 = "";

        public static void doSomething()
        {
            Program.sumNumbers3(32, 11);
            Program objProgram;//definition
            objProgram = new Program();//initilization
            objProgram.sumNumbers4(321, 12);
            //objProgram.sumNumbers i cant call this because it is private
        }
    }

}