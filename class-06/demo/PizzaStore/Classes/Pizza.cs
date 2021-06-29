using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Classes
{
  public class Pizza
  {
    public string Name { get; set; }
    public string[] Ingredients { get; set; }
    public decimal Price { get; set; }
    public string Dough { get; set; } = "Hand Tossed";
    public string Sauce { get; set; }
    public int Slices { get; set; }

    public Pizza(string type)
    {

      if (type == "philly")
      {
        Name = "Cheese";
        Ingredients = new string[] { "Mozzarella", "Romano" };
        Sauce = "Tomato";
        Price = 14.99m;
        Slices = 8;
      }
      else if (type == "white")
      {
        Name = "White";
        Ingredients = new string[] { "Mozzarella", "Ricotta", "Romano", "Roma Tomatoes" };
        Sauce = "Garlic and Oil";
        Price = 19.99m;
        Slices = 8;
      }

      // else ... for sicilian, yuppie, etc.

      Prepare();
      Bake("standard");
      Cut(Slices);
      Deliver("Home");
    }

    public void Prepare()
    {
      Console.WriteLine("Assembling it!");
    }

    public void Bake(string baketype)
    {
      if (baketype == "wood fired")
      {
        Console.WriteLine("Putting it in the wood oven");
      }
      else
      {
        Console.WriteLine("Putt it in the standard oven");
      }
    }

    public void Cut(int slices)
    {
      Console.WriteLine($"Pizza was cut into {slices}");
    }

    public void Deliver(string address)
    {
      Console.WriteLine($"Delivering the pizza to {address}");
    }

  }
}
