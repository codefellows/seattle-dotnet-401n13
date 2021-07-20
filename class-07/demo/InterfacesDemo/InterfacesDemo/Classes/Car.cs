using InterfacesDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesDemo.Classes
{
  public class Car : IDrivable
  {
    bool EngineRunning { get; set; }
    bool IsMoving { get; set; }
    public void Accellerate()
    {
      if (EngineRunning)
      {
        IsMoving = true;
      }
    }

    public void Brake()
    {
      IsMoving = false;
    }

    public void Start()
    {
      EngineRunning = true;
    }

    public void Stop()
    {
      EngineRunning = false;
    }
  }
}
