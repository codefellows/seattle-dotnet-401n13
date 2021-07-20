using System;
namespace WelcomeToCsharp
{
  public class ExceptionsExample
  {
    public static void GenerateSomeErrors()
    {
      // As we change these numbers around, what types of errors can we force?
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
  }
}
