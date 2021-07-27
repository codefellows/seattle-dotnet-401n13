using LendingLibrary.interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingLibrary.classes
{
  public class Library : ILibrary
  {

    private readonly Dictionary<string, Book> books = new Dictionary<string, Book>();
    public int Count => books.Count;

    public void Add(string title, string firstName, string lastName, int numberOfPages)
    {
      Book book = new Book
      {
        Title = title,
        NumberOfPages = numberOfPages,
        Author = new Author
        {
          FirstName = firstName,
          LastName = lastName
        }
      };

      books.Add(title, book);
    }

    public Book Borrow(string title)
    {
      if (!books.ContainsKey(title))
      {
        return null;
      }

      // Find the book and save in a variable
      Book book = books[title];

      // REmove the book from teh library
      books.Remove(title);

      // Return the book
      return book;
    }
    public void Return(Book book)
    {
      books.Add(book.Title, book);
    }

    public IEnumerator<Book> GetEnumerator()
    {
      foreach (Book book in books.Values)
      {
        yield return book;
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}
