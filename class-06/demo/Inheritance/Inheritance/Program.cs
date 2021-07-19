using System;

namespace Inheritance
{
  class Program
  {
    static void Main(string[] args)
    {
      Car johnsCar = new Car();
      johnsCar.Drive();
    }
  }

  class Vehicle
  {
    public int Wheels { get; set; }

    public void Drive()
    {
      Console.WriteLine($"My car with {Wheels} wheels is now driving");
    }
  }

  class Car : Vehicle
  {
    public Car() { }
    public Car(int wheels)
    {
      Wheels = wheels;
    }

    public void Drive()
    {
      Console.WriteLine("Step on the gas pedal");
      base.Drive();
    }
  }

}
