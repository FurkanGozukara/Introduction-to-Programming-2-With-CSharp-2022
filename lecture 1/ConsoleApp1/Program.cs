using System;

namespace MyApp // Note: actual namespace depends on the project name.
{

    //access modifiers : https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers

    //static non static difference : https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members

    public class car
    {
        public int irCarPrice;//it is by default 0  not null
        public string srCarBrand;//class based things are by default null
        public double dblCarWeight;//double by default 0.0

        public static void printCarFeatures(car myCar)
        {
            Console.WriteLine($"first car weight is: {myCar.dblCarWeight}, car price is: {myCar.irCarPrice}, car brand is: {myCar.srCarBrand} for printing curly parantheses {{}} \n \\n");
        }
    }

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

            List<car> cars = secondClass.initCars();
            var vrCars = secondClass.initCars();

            Console.Clear();
            Console.WriteLine("first car weight is: {vrCars[0].dblCarWeight}");
            Console.WriteLine($"first car weight is: {vrCars[0].dblCarWeight}");
            Console.WriteLine("first car weight is: {0}", vrCars[0].dblCarWeight);

            Console.WriteLine($"first car weight is: {vrCars[0].dblCarWeight}, car price is: {vrCars[0].irCarPrice}, car brand is: {vrCars[0].srCarBrand} for printing curly parantheses {{}} \n \\n");
            
            Console.Clear();
            Console.WriteLine("printing car features with my static method");

            car.printCarFeatures(vrCars[0]);

        }

        //this method sum 2 numbers
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
        //so sub methods can access upper private variables
        //but upper methods cant access lower private variables
        public static class subClass
        {
            public static void doanything()
            {
               
                sumNumbers2(321, 321);
            }

            private static int irGG = 32;
        }
    }

    public static class secondClass
    {
        private static string sr1 = "test 1";
        public static string sr2 = "test 2";
        private static string sr3 = "";

        //accessor modifiers public private
        //instance based modifier static non-static
        //return type void or something
        public static void doSomething()
        {
            Program.sumNumbers3(32, 11);
            Program objProgram;//definition
            objProgram = new Program();//initilization
            objProgram.sumNumbers4(321  ,   12);
            //objProgram.sumNumbers i cant call this because it is private
        }

        public static List<car> initCars()
        {
            List<car> carsList;
            carsList = new List<car>();

            car car1 = new car();
            car1.srCarBrand = "BMV";
            car1.irCarPrice = 70000;
            car1.dblCarWeight = 1675.42;

            carsList.Add(car1);

            return carsList;
        }
    }



}