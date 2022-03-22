using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lecture_4
{
    internal class customMethods
    {
        public static void AskAnimals()
        {
            while(true)
            {
                _AskAnimals();
            }
        }

        public void AskAnimalsV2()
        {
            while (true)
            {
                _AskAnimals();
            }
        }

        private static void _AskAnimals()
        {
            //put these code into a new class and call them from that class's instance

            Console.WriteLine("please enter one of the animal names");
            var vrinput = Console.ReadLine()?.ToLower(new System.Globalization.CultureInfo("en-US"));

            //İ = i , I = i , Ğ = g , Ş = s to lower with en-US
            //if you dont apply culture like above ş != s - diacritics difference

            if (vrinput == "cat" || vrinput == "mammal")
            {
                Console.WriteLine("The cat is a domestic species of a small carnivorous mammal.");
            }
            else
                if (vrinput == "dog" || vrinput == "mammal")
            {
                Console.WriteLine("The dog or domestic dog is a domesticated descendant of the wolf which is characterized by an upturning tail.");
            }
            else
                if (vrinput == "ant" || vrinput == "bug")
            {
                Console.WriteLine("Ants are eusocial insects of the family Formicidae and, along with the related wasps and bees, belong to the order Hymenoptera. ");
            }
            else
            {
                Console.WriteLine("we dont have this animal in our database");
            }

            switch (vrinput)
            {
                case "cat":
                    Console.WriteLine("The cat is a domestic species of a small carnivorous mammal.");
                    break;
                case "dog":
                    Console.WriteLine("The dog or domestic dog is a domesticated descendant of the wolf which is characterized by an upturning tail.");
                    break;
                case "mammal":
                    Console.WriteLine("The dog or domestic dog is a domesticated descendant of the wolf which is characterized by an upturning tail.");
                    Console.WriteLine("The cat is a domestic species of a small carnivorous mammal.");
                    break;
                case "ant":
                case "bug":
                    Console.WriteLine("Ants are eusocial insects of the family Formicidae and, along with the related wasps and bees, belong to the order Hymenoptera. ");
                    break;
                default:
                    Console.WriteLine("we dont have this animal in our database");
                    break;
            }
        }
    }
}
