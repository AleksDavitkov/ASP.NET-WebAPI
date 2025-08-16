using homework2_BooksApi.Models;

namespace homework2_BooksApi
{
    public static class BookDb
    {
        public static List<Book> Books { get; set; } = new List<Book>
        {
            new Book { Title = "Python Beginner Guide", Author = "Bob Bobsky" },
            new Book { Title = "A Tour of C++", Author = "John Doe" },
            new Book { Title = "The Lord of the Rings", Author = "J.R.R. Tolkien" },
            new Book { Title = "The February Twist", Author = "Alex Davidson" },
            new Book { Title = "Jurassic Park", Author = "Michael Crichton" },
            new Book { Title = "The Other Half", Author = "Alex Davidson" },
            new Book { Title = "Usque Iterum", Author = "Bob Bobsky" }
        };
    }
}