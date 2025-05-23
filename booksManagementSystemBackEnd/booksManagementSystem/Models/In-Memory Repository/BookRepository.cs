using booksManagementSystem.Models;

public static class BookRepository
{
    private static List<Book> books = new List<Book>();
    private static int nextId = 1;

    public static List<Book> GetAll() => books;

    public static Book GetById(int id) => books.FirstOrDefault(b => b.Id == id);

    public static void Add(Book book)
    {
        book.Id = nextId++;
        books.Add(book);
    }

    public static void Update(Book book)
    {
        var index = books.FindIndex(b => b.Id == book.Id);
        if (index != -1)
        {
            books[index] = book;
        }
    }

    public static void Delete(int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book != null)
            books.Remove(book);
    }
}
