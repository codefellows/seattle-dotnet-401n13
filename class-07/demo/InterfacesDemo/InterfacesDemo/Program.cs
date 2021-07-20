using InterfacesDemo.Classes;
using System;

namespace InterfacesDemo
{
  class Program
  {
    static void Main(string[] args)
    {
      Robot.Speak(); // Static or Class Method
      Robot data = new Robot();
      data.Start();
      data.PutOnGloves(); // Instance Method

    }
  }
}
