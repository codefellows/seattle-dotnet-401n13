using System;
using System.Collections.Generic;

namespace DelegatesDemo
{
  delegate void SayHi(string name);
  delegate bool EvaluateNumber(int number);

  class Program
  {
    static void Main(string[] args)
    {
      IntroduceYourself("John");

      SayHi hey = new SayHi(IntroduceYourself);
      hey("Cathy");

      // Pass it down as an arg and use it in another function
      Greeting(hey);

      // Look, ma ... no Instantiation
      Greeting(IntroduceYourself);

      EvensAndOddsDemo();

    }

    static void IntroduceYourself(string name)
    {
      Console.WriteLine($"Hi, I'm {name}");
    }

    static void Greeting(SayHi yo)
    {
      yo("Zach");
    }

    static void EvensAndOddsDemo()
    {

      int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

      IEnumerable<int> evensBad = GetAllEvenNumbers(numbers);
      foreach (int number in evensBad) { Console.WriteLine($"EVEN (BAD): {number}"); }

      IEnumerable<int> oddsBad = GetAllOddNumbers(numbers);
      foreach (int number in oddsBad) { Console.WriteLine($"ODD (BAD): {number}"); }


      IEnumerable<int> odds = GetTheNumbers(numbers, IsOdd);
      foreach (int number in odds) { Console.WriteLine($"ODD: {number}"); }

      IEnumerable<int> evens = GetTheNumbers(numbers, IsEven);
      foreach (int number in evens) { Console.WriteLine($"Even: {number}"); }

    }

    // Using Delegates to DRY up your code
    // These 2 methods do the same thing, but look at all the duplication
    static IEnumerable<int> GetAllEvenNumbers(int[] numbers)
    {
      foreach (int number in numbers)
      {
        if (number % 2 == 0)
        {
          // What is this doing??
          yield return number;
        }

      }
    }

    static IEnumerable<int> GetAllOddNumbers(int[] numbers)
    {
      foreach (int number in numbers)
      {
        if (number % 2 != 0)
        {
          // What is this doing??
          yield return number;
        }

      }
    }


    // Here, we create a couple of simple delegates that the actual function uses
    // We can make hundreds of these to find factors of any number, squares, etc.
    // And use that same "GetTheNumbers
    static bool IsEven(int num) => num % 2 == 0;
    static bool IsOdd(int num) => num % 2 != 0;

    static IEnumerable<int> GetTheNumbers(IEnumerable<int> numbers, EvaluateNumber evaluator)
    {
      foreach (int number in numbers)
      {

        // Here, instead of looking at the % like in the duplicated functions above,
        // We instead call the delegate function
        if (evaluator(number))
        {
          yield return number;
        }
      }
    }
  }
}


