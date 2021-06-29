using System;
using System.Collections.Generic;
using System.Text;
using Class06Demo.Interfaces;


namespace Class06Demo.Classes
{
  class Car : IDrivable
  {
    public void Accelerate()
    {
      Console.WriteLine("Hammer Down!");
    }

    public void Brake()
    {
      Console.WriteLine("Stomp on It");
    }

    public void Start()
    {
      Console.WriteLine("Turn that Key");
    }

    public void Stop()
    {
      Console.WriteLine("STOP!!!");
    }
  }
}
