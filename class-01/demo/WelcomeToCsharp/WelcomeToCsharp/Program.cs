using System;

namespace WelcomeToCsharp
{
  class Program
  {
    static void Main(string[] args)
    {
      // Miles();
      AllTheErrors();
    }

    private static void AllTheErrors()
    {
      int num = 13;
      int denom = 1;
      int result = 0;

      // JS: let numbers = [22,33,44];
      int[] numbers = { 22, 33, 44 };

      try
      {
        result = num / denom;
        result = numbers[5];
        Console.WriteLine(result);
      }
      catch (DivideByZeroException e)
      {
        Console.WriteLine("You divided by zero!");
      }
      catch (IndexOutOfRangeException e)
      {
        Console.WriteLine("The array isn't that big ...");
      }
      finally
      {
        Console.WriteLine(result);
        Console.WriteLine("You are Done");
      }
    }

    public static void Miles()
    {
      int milesDriven, gallonsOfGas, mpg;

      try
      {

        Console.WriteLine("Enter the miles driven");
        milesDriven = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("How many gallons of gas did you use?");
        gallonsOfGas = Convert.ToInt32(Console.ReadLine());

        mpg = milesDriven / gallonsOfGas;

        Console.WriteLine($"You drove {milesDriven} on {gallonsOfGas} and got {mpg} mpg ...");

      }
      catch (Exception e)
      {
        mpg = 0;
        Console.WriteLine("Whoops, you entered a bad value");
      }

    }
  }
}
