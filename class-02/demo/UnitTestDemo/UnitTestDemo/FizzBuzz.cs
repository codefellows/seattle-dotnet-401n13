using System;

namespace UnitTestDemo
{
    public class FizzBuzz
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static string Convert(int v)
        {
            if ((v % 15) == 0)
            {
                return "FizzBuzz";
            }
            if (v % 3 == 0)
            {
                return "Fizz";
            }
            if (v % 5 == 0)
            {
                return "Buzz";
            }
         
            return v.ToString();
        }

    }
}
