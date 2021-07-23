using System;
using System.Collections.Generic;

namespace DelegatesDemo
{

  // Delegate SayHi = new Delegate(fn, args);

  delegate void SayHi(string name);
  delegate bool EvaluateNumber(int number);

  class Program
  {
    static void Main(string[] args)
    {
      IntroduceYourself("John");

      SayHi hey = new SayHi(IntroduceYourself);

      hey("Cathy");

      Greeting(hey);

      EvensAndOdds();

    }

    static void IntroduceYourself(string name)
    {
      Console.WriteLine($"Hello, {name}");
    }

    static void Greeting(SayHi yo)
    {
      yo("Zach");
    }

    static void EvensAndOdds()
    {

      int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
      IEnumerable<int> evensDoneBadly = GetAllEvenNumbers(numbers);
      foreach (int number in evensDoneBadly)
      {
        Console.WriteLine($"EVEN (BADLY): {number}");
      }

      IEnumerable<int> oddsDoneBadly = GetAllOddNumbers(numbers);
      foreach (int number in oddsDoneBadly)
      {
        Console.WriteLine($"Odd (BADLY): {number}");
      }

      IEnumerable<int> evens = GetTheNumbers(numbers, IsEven);
      foreach (int number in evens)
      {
        Console.WriteLine($"Even (BETTER): {number}");
      }

      static IEnumerable<int> GetAllEvenNumbers(int[] numbers)
      {
        foreach (int number in numbers)
        {
          if (number % 2 == 0)
          {
            yield return number;
          }
        }
      }

      static IEnumerable<int> GetAllOddNumbers(int[] numbers)
      {
        foreach (int number in numbers)
        {
          if (number % 2 > 0)
          {
            yield return number;
          }
        }
      }

      static bool IsEven(int num) => num % 2 == 0;
      static bool IsOdd(int num) => num % 2 != 0;

      static IEnumerable<int> GetTheNumbers(IEnumerable<int> numbers, EvaluateNumber evaluator)
      {
        foreach (int number in numbers)
        {
          if (evaluator(number))
          {
            yield return number;
          }
        }
      }
    }

  } // Class
} // Namespace
