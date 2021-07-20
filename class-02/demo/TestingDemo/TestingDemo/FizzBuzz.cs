using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingDemo
{
  public class FizzBuzz
  {

    // Need a method that takes a number
    // If it's divisble only by 3, return fizz"
    // If it's divisble only by 5, return buzz"
    // If it's divisble by both 3 and 5, return fizzbuzz"
    // Otherwise ... returnhe number

    /// <summary>
    /// This will evaluate a number, returning fizz, buzz or fizzbuzz (3/5/15)
    /// </summary>
    /// <param name="num"></param>
    /// <returns>string ... as noted</returns>



    // DEMO 1: Do FizzBuzz using an if statement and write tests

    //public static string Convert(int num)
    //{

    //  if(num % 15 == 0) { return "fizzbuzz";  }
    //  else if(num % 5 == 0) { return "buzz";  }
    //  else if(num % 3 == 0) { return "fizz";  }
    //  else {  return num.ToString();  }

    //}

    // DEMO 2: Refactor Convert to use a switch statement. Your tests should
    //         still work. This is what it means to refactor: New implementation
    //         same signature

    public static string Convert(int num)
    {

      switch (num % 15)
      {
        case 0:
          return "fizzbuzz";

        case 5:
        case 10:
          return "buzz";

        case 3:
        case 6:
        case 9:
        case 12:
          return "fizz";

        default:
          return num.ToString();
      }

    }

  }
}
