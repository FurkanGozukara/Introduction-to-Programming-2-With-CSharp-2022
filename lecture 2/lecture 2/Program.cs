using System;

namespace Lecture2 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            exClass1.doStuff();
            exClass1.doStuff(100+250);
            exClass1.doStuff(nr2: 150);
            var vrResult = exClass1.aSpecialMethod("the value of ; 2.2^5");
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
        public static void doStuff(long nr1 = 25, long nr2 = 15)
        {
            //Program.sumTwoNumbers_nonStatic(32,11);//to fix this we need to change like below
            Program myProgram = new Program();
            myProgram.sumTwoNumbers_nonStatic(32, 11);

            Program.sumTwoNumbers_Static(32, 11);

            Console.WriteLine(Program.sumTwoNumbers_Static(nr1, nr2));
        }

        //the value of ; 2.2^5
        public static Tuple<int,double,string> aSpecialMethod(string srBase)
        {
            var vrSplit = srBase.Split(';');
            string srTitle = srBase.Split(';')[0];
            double dblBase = double.Parse(vrSplit[1].Split('^').FirstOrDefault());

            int ir_nr1 = Convert.ToInt32(vrSplit[0].Split('^').FirstOrDefault());

            return new Tuple<int, double, string>(ir_nr1, dblBase, srTitle);
        }
    }

    //i want to return integer double and string from a single method
    //i can use class object
    //i can use struct object
    //i can use a list that hold object type
    //i can use tuples


}