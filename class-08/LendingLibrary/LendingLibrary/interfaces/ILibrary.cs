using LendingLibrary.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingLibrary.interfaces
{
  public interface ILibrary : IReadOnlyCollection<Book>
  {
    /// <summary>
    /// Add a Book to the library.
    /// </summary>
    void Add(string title, string firstName, string lastName, int numberOfPages);

    /// <summary>
    /// Remove a Book from the library with the given title.
    /// </summary>
    /// <returns>The Book, or null if not found.</returns>
    Book Borrow(string title);

    /// <summary>
    /// Return a Book to the library.
    /// </summary>
    void Return(Book book);
  }
}
