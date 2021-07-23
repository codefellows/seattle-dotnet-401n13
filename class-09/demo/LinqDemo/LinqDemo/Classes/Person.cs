using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo.Classes
{
  class Person
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int YearOfBirth { get; set; }

    public Person(string first, string last, int yob)
    {
      FirstName = first;
      LastName = last;
      YearOfBirth = yob;
    }
  }
}
