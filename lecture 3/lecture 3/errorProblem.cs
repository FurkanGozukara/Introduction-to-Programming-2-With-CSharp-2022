using System;

namespace lecture_1503
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //i want you to use student class and set and read studentAge property and print to the console

            student csStudent = new student();
            Console.WriteLine(csStudent.studentAge);
            csStudent.studentAge = 110;
            Console.WriteLine(csStudent.studentAge);
            csStudent.studentAge = 5;
            Console.WriteLine(csStudent.studentAge);
            csStudent.studentAge = 55;
            Console.WriteLine(csStudent.studentAge);
        }



    }
    public class student
    {
        public student()//this is constructer class
        {
            _studentAge = -1;
        }

        private int _studentAge;

        public int studentAge
        {
            get
            {
                if (_studentAge < 10)
                {
                    return 11;
                }
                return _studentAge;
            }

            set
            {
                if (value > 100)
                {
                    _studentAge = 90;
                }
                else
                    _studentAge = value;
            }
        }

    }
}
