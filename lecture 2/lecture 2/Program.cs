using System;
using System.Globalization;
using System.Linq;

namespace Lecture2 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            exClass1.doStuff();
            exClass1.doStuff(100 + 250);
            exClass1.doStuff(nr2: 150);
            var vrResult = exClass1.aSpecialMethod("the value of ; 2.2^5");

            //modify your method to handle this input gracefully as well
            var vrResult2 = exClass1.aSpecialMethod("the value of ; 2a.2^a5");
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
        public static Tuple<int, double, string> aSpecialMethod(string srBase)
        {
            CultureInfo ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            var vrSplit = srBase.Split(';');
            string srTitle = srBase.Split(';')[0];
            srTitle = srTitle.Trim();
            srTitle = srTitle.TrimEnd();

            double dblBase =-1;
            //try
            //{
            //    dblBase = double.Parse(vrSplit[1].Split('^').FirstOrDefault());
            //}
            //catch (Exception E)
            //{
            //    Console.WriteLine($"an exception occured when parsing double value. the exception message is " + E.Message + "\r\n\r\n" + E.StackTrace);
            //}

            bool blTryParseResult = double.TryParse(vrSplit[1].Split('^').FirstOrDefault(), out dblBase);

            Console.WriteLine($"the double conversation of {vrSplit[1].Split('^').FirstOrDefault()} resulted in : {blTryParseResult.ToString()} and the result is {dblBase.ToString()}");

            //2.2 in Turkish it is written as 2,2 
            var vrTemp = vrSplit[1];
            var vrTemp2 = vrTemp.Split('^').LastOrDefault();

            int ir_nr1 = 0;

            try
            {
                ir_nr1 = Convert.ToInt32(vrTemp2);
            }
            catch
            {
            }
            return new Tuple<int, double, string>(ir_nr1, dblBase, srTitle);
        }
    }

    //i want to return integer double and string from a single method
    //i can use class object
    //i can use struct object
    //i can use a list that hold object type
    //i can use tuples


}