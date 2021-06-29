namespace Class04Demo.Classes
{
    class Book
    {
        public string Title { get; set; }
        public Author Author { get; set; }
        public string Publisher { get; set; }
        public int NumberOfPages { get; set; }
        public bool Signed { get; set; }
        public bool CheckedOut { get; set; }


        public Book(string title, Author author, string publisher, int numberOfPages)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            NumberOfPages = numberOfPages;

        }


    }
}
