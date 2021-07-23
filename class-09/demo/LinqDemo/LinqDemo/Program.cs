using System;
using LinqDemo.Classes;
using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqDemo
{
  class Program
  {
    static void Main(string[] args)
    {
      Person[] people =
      {
        new Person("Kate","Austin", 1973),
        new Person("Jack", "Shepard", 1981),
        new Person("Hugo", "Reyes", 2000)
      };

      /*

        SELECT FirstName, LastName
        FROM people
        WHERE YearOfBirth > 1990
        ORDER BY LasName
       */

      // LinQ Equivalent:
      // "query" is the answer to the question, not ther question itself!
      var query = from person in people
                  select person;


      foreach (var person in query)
      {
        Console.WriteLine(person.FirstName);
      }

      // Filtered:
      var filtered = from person in people
                     where person.YearOfBirth > 1999
                     select new { fn = person.FirstName, ln = person.LastName };

      Console.WriteLine("Filtered ...");
      foreach (var person in filtered)
      {
        Console.WriteLine(person.fn);
      }

      // Chaining Methods
      var young = people
                  .Where(person => person.YearOfBirth < 2000)
                  .Select(person => new { person.FirstName, person.LastName });

      Console.WriteLine("Filtered with methods, not linq");
      foreach (var person in young)
      {
        Console.WriteLine(person.FirstName);
      }

    }
  }
}
