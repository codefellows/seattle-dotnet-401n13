using System;
using System.Collections.Generic;
using System.Text;

namespace Class04Demo.Classes
{
    class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Author(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public void SignBook(Book book)
        {
            book.Signed = true;
        }


    }
}
