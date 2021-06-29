using Class04Demo.Classes;
using System;

namespace Class04Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            MyPerson();
        }

        static void MyPerson()
        {
            // instantiate an object from a class the object is named "amanda" and the class/type is named "Person"
            Person instructor = new Person();

            // This is the "set" accessor doing it's job.
            instructor.Name = "Amanda";

            // this is the "Get" accessor doing it's job. 
            string name = instructor.Name;


            instructor.FavoriteColor = "Red";

            instructor.MiddleName = "Josie";

            instructor.Age = 28;

            Console.WriteLine($"{instructor.Name} is {instructor.Age} years old and has the middle name of {instructor.MiddleName}. Her favorite color is {instructor.FavoriteColor}");
            
        }
    }
}
