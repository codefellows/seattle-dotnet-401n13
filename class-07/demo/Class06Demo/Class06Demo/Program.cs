using Class06Demo.Interfaces;
using System;

using Class06Demo.Classes;

namespace Class06Demo
{
  class Program
  {
    static void Main(string[] args)
    {
      Car mazda = new Car();
      Robot data = new Robot();
      Employee john = new Employee(1000000, "WA");
      john.Drive(mazda);

      IDriveExample(data);
    }

    public static void IDriveExample(IDrive driver)
    {
      Console.WriteLine($"My License is from the state of {driver.StateLicense}");
      Console.WriteLine($"I adjust my settings by: {driver.AdjustSettings()}");
    }
  }
}
