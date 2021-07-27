using LendingLibrary.classes;
using System;

namespace LendingLibrary
{
  class Program
  {
    private static readonly Library library = new Library();
    private static readonly Satchel<Book> satchel = new Satchel<Book>();
    static void Main(string[] args)
    {
      LoadLibrary();
      UserInterface();
    }

    static void LoadLibrary()
    {
      library.Add("Guide to Craps", "John", "Cokos", 44);
      library.Add("Coding for Dummies", "Code", "Whisperer", 1);
      library.Add("Star Trek vs Star Wars", "Darth", "Picard", 10);
    }

    static void UserInterface()
    {
      while (true)
      {
        Console.WriteLine("WELCOME TO THE LIBRARY");
        Console.WriteLine("========================");
        Console.WriteLine("Pick an Option Below");
        Console.WriteLine("========================");
        Console.WriteLine("1. View All Books");
        Console.WriteLine("2. Add New Book");
        Console.WriteLine("3. Borrow a Book");
        Console.WriteLine("4. Return a Book");
        Console.WriteLine("5. View My Satchel");
        Console.WriteLine("6. Exit");
        Console.WriteLine("");

        string choice = Console.ReadLine();

        switch (choice)
        {
          case "1":
            ShowLibrary();
            break;
          case "2":
            AddBook();
            break;
          case "3":
            BorrowBook();
            break;
          case "4":
            ReturnBook();
            break;
          case "5":
            ViewSatchel();
            break;
          case "6":
            return;
          default:
            Console.WriteLine("Invalid Option");
            Console.WriteLine();
            break;
        }
      }
    }

    static void ShowLibrary()
    {
      Console.Clear();
      Console.WriteLine("Library...");
      Console.WriteLine("==========");
      Console.WriteLine();
      int counter = 1;
      foreach (Book book in library)
      {
        Console.WriteLine($"  {counter++}. {book}");
      }

      Console.WriteLine();
      Console.WriteLine();
      Console.WriteLine();

    }

    static void AddBook()
    {
      Console.Clear();
      Console.WriteLine("Add Book...");
      Console.WriteLine("==========");

      Console.WriteLine();
      Console.Write("Book Title: ");
      string title = Console.ReadLine();

      Console.WriteLine();
      Console.Write("Author First Name: ");
      string firstName = Console.ReadLine();

      Console.WriteLine();
      Console.Write("Author Last Name: ");
      string lastName = Console.ReadLine();

      Console.WriteLine();
      Console.Write("# pages: ");
      string pages = Console.ReadLine();
      int.TryParse(pages, out int numPages);

      library.Add(title, firstName, lastName, numPages);

    }

    static void BorrowBook()
    {
      Console.Clear();
      Console.WriteLine("Borrow Book...");
      Console.WriteLine("==========");
      foreach (Book book in library)
      {
        Console.WriteLine(book);
      }

      Console.WriteLine();
      Console.Write("Enter Book Title (exactly):");
      string selection = Console.ReadLine();

      Book borrowed = library.Borrow(selection);
      Console.WriteLine(borrowed);

      satchel.Pack(borrowed);
    }

    static void ReturnBook()
    {
      Console.Clear();
      Console.WriteLine("Return Book");
      Console.WriteLine("==========");

      int counter = 1;
      foreach (Book book in satchel)
      {
        Console.WriteLine($"  {counter++}. {book}");
      }

      Console.WriteLine("Which Book To Return?");
      int selection = Convert.ToInt32(Console.ReadLine()) - 1;

      Book bookToReturn = satchel.Unpack(selection);

      library.Return(bookToReturn);

    }

    static void ViewSatchel()
    {
      Console.Clear();
      Console.WriteLine("View My Satchel");
      Console.WriteLine("==========");
      // List the books in the satchel
    }

  }

}
