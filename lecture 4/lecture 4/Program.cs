using System;
using lecture_4;

namespace lecture_1503
{
    internal class Program
    {
        static void Main(string[] args)
        {
            doThings();

            //lecture_4.customMethods.AskAnimals();
            // customMethods.AskAnimals();

            customMethods myMethods = new customMethods();
            myMethods.AskAnimalsV2();

        }

        static void doThings()
        {
            Random random = new Random();
            List<int> listOfnumbers = new List<int>();
            int rnd;

            for (int i = 0; i < 2000; i++)
            {
                rnd = random.Next(0, 2000);
                listOfnumbers.Add(rnd);

            }
            returnList(listOfnumbers);
            Console.WriteLine("Returns this");
            foreach (var item in listOfnumbers)
            {
                Console.WriteLine(item);
            }

        }
        public static void returnList(List<int> numbersList)
        {
            var vrSecondList = numbersList.ToList();//deep clone
            var vrList2 = numbersList;//this wont fix enumaration collection error //this is shallow clone

            foreach (var vrPerNumber in vrSecondList)
            {
                if (IsPrime(vrPerNumber) == false)
                {
                    numbersList.Remove(vrPerNumber);
                }
            }

            for (int i = 0; i < vrSecondList.Count; i++)//this uses lesser memory
            {
                if (IsPrime(vrSecondList[i]) == false)
                {
                    vrSecondList.RemoveAt(i);
                    i--;
                }
            }
        }

        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

    }

}