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

            //method overloading
            var vr1 = customSum(32.12, 22, 51);
            var vr2 = customSum(11, 0.22, 33);//double+double+int or int+double+int
            var vr4 = customSum(11d, 0.22, 33); // or var vr4 = customSum(11.0, 0.22, 33);
            var vr3 = customSum("11", 43, "35");

            student myStudent = new student { irStudentID = 100, srStudentFirstName = "Furkan", srStudentLastName = "Gözükara"};

            myStudent.srStudentCard = $"Student ID: {myStudent.irStudentID}, {myStudent.srStudentFirstName} {myStudent.srStudentLastName}";

            Console.WriteLine(myStudent.srStudentCard);

            Console.WriteLine();

            Console.WriteLine(myStudent.srAutomaticStudentCard);

            myStudent.irAge = 200;

            Console.WriteLine("age : " + myStudent.irAge);//

            myStudent.irAge = 1;
            Console.WriteLine("age : " + myStudent.irAge);
        }

        //double + int + int
        public static double customSum(double dbl1, int ir1, int ir2)
        {
            return dbl1 + ir1 + ir2;
        }

        //int + double + int
        public static double customSum(int ir1, double dbl2, int ir2)
        {
            return ir1 + dbl2 + ir2;
        }

        //double + double + int
        public static double customSum(double dbl1, double dbl2, int ir2)
        {
            return dbl1 + dbl2 + ir2;
        }

        //string + double + string
        public static string customSum(string str1, double dbl2, string str2)
        {
            return str1 + dbl2 + str2;
        }

        //string + string + double
        public static string customSum(string str12, string str22, double dbl22)
        {
            return str12 + dbl22 + str22;
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

            double dblBase = -1;
            //try
            //{
            //    dblBase = double.Parse(vrSplit[1].Split('^').FirstOrDefault());
            //}
            //catch (Exception E)
            //{
            //    Console.WriteLine($"an exception occured when parsing double value. the exception message is " + E.Message + "\r\n\r\n" + E.StackTrace);
            //}

            bool blTryParseResult = double.TryParse(vrSplit[1].Split('^').FirstOrDefault(), out dblBase);//if try parse fails, the ouput will become default value and default value of double is 0

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

    public class student
    {
        public int irStudentID;//field
        public string srStudentFirstName { get; set; }//property

        public string srStudentLastName;//field
        public string srStudentCard { get; set; }//property

        public string srAutomaticStudentCard // property and overloaded get
        {
            get//whenever you access srAutomaticStudentCard property for reading, this method will be always called
            {
                //this means that the instance of the parent class which is student
                return $"Student ID: {this.irStudentID}, {this.srStudentFirstName} {this.srStudentLastName}";
            }
        }
        private int _irAge = 50;
        public int irAge 
        {
            get { return _irAge; }

            set
            {
                if (value > 100)
                    _irAge = 100;
                if (value < 10)
                    _irAge = 10;
            }
        }
    }

}