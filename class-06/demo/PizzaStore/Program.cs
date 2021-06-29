using System;


using PizzaStore.Classes;

namespace PizzaStore
{
  class Program
  {
    static void Main(string[] args)
    {
      Store sams = new Store()
      {
        Name = "Sams Pies",
        Address = "Front Street",
        Phone = "215-555-1212"
      };

      sams.Open();
      Pizza pizza = sams.Order("philly");
      sams.Close();

      Console.WriteLine(sams.ToString());
    }
  }
}
