using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Classes
{
  public abstract class Party
  {
    public abstract int MaxNumberOfGuests { get; set; }
    public abstract decimal Budget { get; set; }
    public abstract string Venue { get; set; }
    public string Theme { get; set; }

    public abstract void Setup();
    public abstract void TearDown();

  }
}
