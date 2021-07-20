using System;
namespace WelcomeToCsharp
{
  public class TryCatchExample
  {
    public static void CatchUserError()
    {
      int milesDriven, gallonsOfGas, mpg;

      try
      {

        // Let's get some input from the user...
        Console.WriteLine("Enter the miles driven");

        // Need to make text entry a string
        milesDriven = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("How many gallons of gas did you use?");
        gallonsOfGas = Convert.ToInt32(Console.ReadLine());

        // Sure hope they entered a non-zero number here!
        mpg = milesDriven / gallonsOfGas;

        Console.WriteLine($"You drove {milesDriven} on {gallonsOfGas} and got {mpg} mpg ...");

      }

      // This catches ANY error ... what other types of errors can we expect here?
      catch (Exception e)
      {
        mpg = 0;
        Console.WriteLine("Whoops, you entered a bad value");
      }

    }
  }
}
