using CollectionsAndEnums.classes;
using System;
using System.Collections.Generic;

namespace CollectionsAndEnums
{
  class Program
  {
    static void Main(string[] args)
    {
      // EnumExample();
      // ListExample();
      // DictionaryExample();
      CustomCollectionExample();
    }

    static void EnumExample()
    {
      DayOfTheWeek dow = DayOfTheWeek.Friday;
      Console.WriteLine($"The selected is {dow}");
      Console.WriteLine($"The number of the day is {(int)dow}");
      Console.WriteLine($"The day of number 157 is {(DayOfTheWeek)157}");

      foreach (int i in Enum.GetValues(typeof(DayOfTheWeek)))
      {
        Console.WriteLine(i);
      }

      foreach (string day in Enum.GetNames(typeof(DayOfTheWeek)))
      {
        Console.WriteLine(day);
      }

    }

    static void ListExample()
    {

      // Declare a lvariable called family that is of type List of strings and intantiate it
      List<string> family = new List<string>();
      family.Add("John");
      family.Add("Cathy");
      family.Add("Zach");
      family.Add("Allie");
      family.Add("Rosie");

      foreach (string person in family)
      {
        Console.WriteLine(person);
      }

      List<int> numbers = new List<int>() { 2, 4, 6, 8 };

      foreach (int num in numbers)
      {
        Console.WriteLine($"{num} squared is {num * num}");
      }
    }

    static void DictionaryExample()
    {
      Dictionary<int, string> bands = new Dictionary<int, string>();

      bands.Add(1, "Slayer");
      bands.Add(2, "Imagine Dragons");
      bands.Add(3, "AbbA");

      bands.TryGetValue(27, out string band);
      Console.WriteLine(band);
      Console.WriteLine(bands[2]);

      Dictionary<string, int> myStuff = new Dictionary<string, int>();
      myStuff.Add("Computers", 2);
      myStuff.Add("Houses", 1);
      myStuff.Add("Dice", 44);

      myStuff["Dice"] = 66;


      foreach (KeyValuePair<string, int> thing in myStuff)
      {
        // printf or sprintf
        Console.WriteLine("Key: {0}, Value: {1}", thing.Key, thing.Value);
      }
    }

    static void CustomCollectionExample()
    {
      CustomCollection<int> numbers = new CustomCollection<int>();
      numbers.Add(2);
      numbers.Add(4);
      numbers.Add(6);
      numbers.Add(8);

      foreach (int number in numbers)
      {
        Console.WriteLine($"The Number is {number}");
      }

      CustomCollection<int> odds = new CustomCollection<int>() { 1, 3, 5, 7 };
      foreach (int number in odds)
      {
        Console.WriteLine(number);
      }

    }
  }
}
