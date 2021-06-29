using CollectionsAndEnums.Classes;
using System;
using System.Collections.Generic;

namespace CollectionsAndEnums
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");

      EnumExample();
      GenericExample();
      DictionaryExample();
      CustomCollectionExample();

    }

    static void EnumExample()
    {
      Classes.DayOfWeek dow = Classes.DayOfWeek.Saturday;
      Console.WriteLine($" Convert to int {(int)dow}"); // output 6
      Console.WriteLine($" Convert to Day of Week { (Classes.DayOfWeek)6}"); // output Saturday

      Date date = new Date()
      {
        DayOfMonth = 12,
        Month = Classes.Months.July,
        DayOfWeek = Classes.DayOfWeek.Thursday,
      };

      Console.WriteLine(date.Month);

    }


    static void GenericExample()
    {
      List<string> myList = new List<string>();

      myList.Add("Amanda");
      myList.Add("Greg");
      myList.Add("Meggan");
      myList.Add("Jon");
      myList.Add("Richard");
      myList.Add("Evan");

      // traverse through the list and output the items
      foreach (string item in myList)
      {
        Console.WriteLine(item);
      }

      // Collection initializers, just like arrays
      List<int> myNumbers = new List<int>
            {
                4,8,15,16,23,42
            };

      Console.WriteLine("============");
      foreach (int number in myNumbers)
      {
        Console.WriteLine(number);
      }

      Console.WriteLine("===========");

      myList.Remove("Greg");
      Console.WriteLine("Removing Greg");

      // traverse through the list and output the items
      foreach (string item in myList)
      {
        Console.WriteLine(item);
      }



    }

    static void DictionaryExample()
    {
      Dictionary<int, string> myDictionary = new Dictionary<int, string>();
      myDictionary.Add(1, "Cat");
      myDictionary.Add(2, "Dog");
      myDictionary.Add(3, "Bird");

      myDictionary.TryGetValue(3, out string answer);
      Console.WriteLine(answer);

      foreach (KeyValuePair<int, string> animal in myDictionary)
      {
        Console.WriteLine("Key: {0}, Value: {1}", animal.Key, animal.Value);
      }

    }

    static void CustomCollectionExample()
    {
      NumberList<int> list = new NumberList<int>();
      list.Add(4);
      list.Add(8);
      list.Add(15);
      list.Add(16);
      list.Add(23);
      list.Add(42);

      foreach (int number in list)
      {
        Console.WriteLine(number);
      }

      NumberList<int> numbers = new NumberList<int>
            {
                1,2,3,4,5,6,7
            };

      Console.WriteLine("========");

      foreach (int number in numbers)
      {
        Console.WriteLine(number);
      }


    }
  }
}
