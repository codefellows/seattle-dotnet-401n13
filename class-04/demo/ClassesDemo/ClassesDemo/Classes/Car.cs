using System;
namespace ClassesDemo.Classes
{
  public class Car
  {

    private string clr;
    private Engine engine;

    // { get; set; }
    // Getter function
    // Setter function
    public string Make { get; set; }
    public bool IsDriving { get; set; }
    public int Speed { get; set; }
    public Engine DriveTrain { get; set;  }

    public string Color
    { 
      get { return clr; }
      set { 
        if( value == "brown" )
        {
          clr = "Red"; 
	      }
        else {
          clr = value;
	      }
      }
    }

    // Constructor
    public Car()
    {
    }

    public Car(string make, string color, int cyl)
    {
      Console.WriteLine("I am in the overloaded constructor...");
      Make = make;
      Color = color;
      DriveTrain = new Engine(cyl);
    }

    public void Drive() 
    {
      IsDriving = true;
    }

    public void Stop()
    {
      IsDriving = false;
    }

  }
}
