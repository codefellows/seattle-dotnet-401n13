using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Classes
{
  public class Store
  {

    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public bool IsOpen { get; set; }

    public void Open()
    {

      Console.WriteLine("Turn on the Oven");
      Console.WriteLine("Put $ in the register");
      Console.WriteLine("Cut the cheese");
      Console.WriteLine("Make the gravy");

      IsOpen = true;

    }

    public void Close()
    {
      Console.WriteLine("Turn Off the Ovens");
      Console.WriteLine("Clean the dishes");
      Console.WriteLine("Clean the tables");
      Console.WriteLine("Clean the Floor");
      Console.WriteLine("Count the $");

      IsOpen = false;
    }

    public Pizza Order(string PizzaType)
    {
      return new Pizza(PizzaType);
    }
  }
}
