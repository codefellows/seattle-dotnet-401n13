using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingLibrary.classes
{
  public class Book
  {
    public string Title { get; set; }
    public int NumberOfPages { get; set; }
    public Author Author { get; set; }

    public override string ToString()
    {
      return $"{Title} - {Author}";
    }
  }

}
