using InterfacesDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesDemo.Classes
{
  public class Robot : IDrivable, IDrive
  {
    public string StateLicense { get; set; } = "US";
    bool HasFeet { get; set; }
    bool GlovesOn { get; set; } = false;

    public static void Speak()
    {
      Console.WriteLine("hi");
    }
    public void Accellerate()
    {
      Console.WriteLine("Robot is walking");
    }

    public void AdjustSeat()
    {
      Console.WriteLine("I always fit");
    }

    public void Brake()
    {
      Console.WriteLine("I do not stop ever");
    }

    public void InsertKey()
    {
      Console.WriteLine("I am the key");
    }

    public void PutOnGloves()
    {
      Console.WriteLine("I don't need gloves, I'm a robot");
    }

    public void Start()
    {
      Console.WriteLine("Hello World");
    }

    public void Stop()
    {
      Console.WriteLine("Plugging in for more oil");
    }
  }
}
