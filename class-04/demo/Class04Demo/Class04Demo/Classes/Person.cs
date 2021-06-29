using System;

namespace Class04Demo.Classes
{
    class Person
    {

        // !Static keyword!: static means that it is connected to the class and not the object. Meaning that any objects that get created will not be able to access that item because it is with the class, not the object. static means it is shared. If you change something in the class that is static, it will affect all instances of the class.

        // This is a property. It looks like a field, but it has getters and setters attached to it. they can contain logic. 
        // GET - is used to return the property value
        // SET - is used to assign a new value.
        // Props can be read/write (have both a getter and a setter), 
        // if only a get it's readonly.
        // if only a set, its write only (less common/rare) used to restrict access to sensitive data. 

        #region AutoImplemented Properties
        public string FavoriteColor { get; set; } = "Red";

        // With auto implements properties, a backing field is created anyway...we just don't see it. This can be used to an advantage of not having to worry about extra floating variables. 

        // If we plan on having logic in our properties, we must create our own backing stores. Auto implemented properties are not good options for these types of properties. 

        #endregion


        #region backing fields
        // Once upon a time, "backing fields" were a thing. this is before we had auto implemented properties. 
        // backing fields are private variables to the class that would assist in the constructor of a property. 
        // for example: 

        private string name; // the name field is a backing store. note that it is private
        

        // This method of setting properties is very "old school" and is not used very much anymore. we primarily depend on auto implemented properties now instead of depending on a backing store. 
        public string Name
        {
            get
            {
                return name; // return the value stored in the name variable. 
            }
            set
            {
                name = value; // set the name property to the incoming value.
            }

        }

        #endregion


        #region Property Logic

        int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if ((value > 18) && value < 120)
                {
                    age = value;
                }
                else
                {
                    throw new System.Exception("Invalid!");
                }
            }
        }

        #endregion


        #region MiddleName prop with GET Logic
        // We can set default get logic too if we like.
        string middleName;
        public string MiddleName
        {
            get
            {
                return middleName != null ? middleName : "NA";
            }
            set
            {
                middleName = value;
            }
        }

        #endregion


        #region DON'T DO THIS
        private int number;
        public int Number
        {
            get
            {
                return number++;   // Don't do this. This directly manipulating what is being retrieved
            }
        }

        #endregion


        #region Accessibility Levels
        // It is possible for you to have the `get` be one accessibility level, while the `set` is different.This will allow the getter to be accessible by anyone(public)a nd the set to only be changed from within the class (private)
        #endregion

        // Constructor that requires name and age
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        // Default Empty Constructor
        // This is given to us by default. The moment we decide to create a new constructor, we must 
        // explicitly state we still want this constructor by defining it. 
        public Person()
        {

        }

        void DrinkCoffee()
        {
            Console.WriteLine("I will take a Starbucks");
        }

        #region Method Overloading
        void Speak(string comment)
        {
            Console.WriteLine($"{Name} says {comment}");
        }

        void Speak(Book book)
        {
            Console.WriteLine(book.Title);
        }

        #endregion

    }
}
