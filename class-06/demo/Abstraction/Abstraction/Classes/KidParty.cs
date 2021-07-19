using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Classes
{
  class KidParty : Birthday
  {
    public override string[] Presents { get; set; }
    public override string Venue { get; set; }
    public override int Age { get; set; }

    public override void OpenPresents(string[] presents)
    {
      Console.WriteLine("Opening Presents");
    }

    public override void PlayGames()
    {
      // Iterate the games list
      Console.WriteLine("Playing the games");
    }

    public override void Setup()
    {
      Console.WriteLine("Setting things up");
    }

    public override void TearDown()
    {
      Console.WriteLine("Cleaning it up");
    }

    // Optionally override the birthday party's default ...
    // public override void SingHappyBirthday()
    // {
    // Console.WriteLine("Happy birthday to you ...");
    // }
  }
}
