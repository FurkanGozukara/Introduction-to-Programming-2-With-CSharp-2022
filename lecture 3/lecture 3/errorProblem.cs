using System;
using lecture_3;


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


            string vrTest1 = null;

            if (vrTest1?.Trim().ToLower() == "break")
            {
                Console.WriteLine("test 1 is not null");
            }

            if (vrTest1 != null)//this is equal to above
            {
                if (vrTest1.Trim().ToLower() == "break")
                {
                    Console.WriteLine("test 1 is not null");
                }
            }

            //if (vrTest1.Trim().ToLower() == "break")
            //{
            //    Console.WriteLine("test 1 is not null");
            //}

            //keep all instances of student object and after user breaks the loop print all of them on the screen with a new static method

            List<student> lstStudents = new List<student>();

            while (true)//this means it will loop forever until you break
            {
                //add a mechanism to break while loop from user input
                Console.WriteLine("enter student age as numeric. to break enter break");
                var vrUserInput = Console.ReadLine();

                if (vrUserInput?.Trim().ToLower() == "break")//? means that if {vrUserInput is null do not continue executing that code line
                    break;

                if (vrUserInput != null)//this is equal to above
                {
                    if (vrUserInput.Trim().ToLower() == "break")
                        break;
                }

                student csUserStudent = new student();
                int irTestAge = 0;
                if (Int32.TryParse(vrUserInput, out irTestAge))
                {
                    csUserStudent.studentAge = irTestAge;
                }
                Console.WriteLine("user entered age = {csUserStudent.studentAge}");
                Console.WriteLine($"user entered age = {csUserStudent.studentAge}");

                lstStudents.Add(csUserStudent);
            }

            
            lecture_3.staticMethods.printStudentsWithFor(lstStudents);

            //with adding using lecture_3; now we have all classes and methods of that name space
            //staticMethods.printStudentsWithFor(lstStudents);

            staticMethods.printStudentsWithForEach(lstStudents);

            student parameterStudent = new student(500);//we are giving a parameter to the class constructor
        }
    }
    public class student
    {


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
        public student()//this is constructer class // signature is empty
        {
            studentAge = -1;
        }

        public student(int initValue)//this is constructer class //signature is int
        {
            studentAge = initValue;
        }
    }
}
