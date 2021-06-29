using System;
using System.Collections.Generic;
using System.Text;

namespace Class04Demo.Classes
{
    class Library
    {
        public Book[] Books { get; set; }
        public string Name { get; set; }

        public Library(string name)
        {
            Name = name;
            Books = new Book[10];
        }

        public Book CheckOutBook(string bookName)
        {
            Book book = null;

            for (int i = 0; i < Books.Length; i++)
            {
              if(Books[i].Title == bookName)
                {
                    Books[i].CheckedOut = true;
                    book = Books[i];

                }

            }
            return book;
        }
    }
}
