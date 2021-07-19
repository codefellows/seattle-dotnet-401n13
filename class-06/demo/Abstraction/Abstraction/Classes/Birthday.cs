using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Classes
{
  public abstract class Birthday : Party
  {
    // This is polymorphism ... we are overriding!
    public override int MaxNumberOfGuests { get; set; } = 100;
    public override decimal Budget { get; set; } = 1000.00m;
    public abstract int Age { get; set; }

    public abstract string[] Presents { get; set; }

    // Children (sub-classes) MUST implement these methods
    public abstract void PlayGames();
    public abstract void OpenPresents(string[] presents);

    // Children (sub-classes) MAY implement this method. We gave a default, they can override
    public virtual void SingHappyBirthday()
    {
      Console.WriteLine("Singing the Happy Birthday Song");
    }

  }

}
