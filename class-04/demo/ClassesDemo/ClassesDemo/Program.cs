using System;
using ClassesDemo.Classes;

namespace ClassesDemo
{
  class Program
  {
    static void Main(string[] args)
    {
      // Example 1: Create an instance and set props afterwards
      // johnsCurrentCar is on the stack
      // new Car() is in the heap
      Car johnsCurrentCar = new Car();

      // What actually happens is that C# calls johnsCurrentCar.Make.set("mazda");
      johnsCurrentCar.Make = "mazda";
      johnsCurrentCar.Color = "brown";

      johnsCurrentCar.Drive();
      johnsCurrentCar.Stop();

      /// What actually happens is ..johnsCurrentCar.Make.get()
      Console.WriteLine($"John Drives a {johnsCurrentCar.Color} {johnsCurrentCar.Make} ... is Driving? {johnsCurrentCar.IsDriving}");

      // Create an instance and set props in one step
      Car johnsLastCar = new Car()
      {
        Make = "Ford",
        Color = "Black"
      };

      Console.WriteLine($"John Previously Drove a {johnsLastCar.Color} {johnsLastCar.Make} ... is Driving? {johnsLastCar.IsDriving}");


      Car johnsFirstCar = new Car("Toyota Celica", "Gold", 4);

      Console.WriteLine($"John First Drove a {johnsFirstCar.Color} {johnsFirstCar.Make} ... is Driving? {johnsFirstCar.IsDriving}");
      Console.WriteLine(johnsFirstCar.DriveTrain.Cylinders);
    }
  }
}
