namespace BookStore.Models.Repositories;
#nullable disable

public class BookRepository : IBookStoreRepository<Book>
{


    List<Book> books;
    public BookRepository()
    {
        books = new List<Book>()
        {
            new Book
            {
                bookId = 1,
                bookName = "ASP in Action",
                bookDescription = "Trying ASP from scratch",
                Author = new Author {authourId=1, authorName = "Gerges"}
            },
            new Book
             {
                 bookId = 2,
                 bookName = "ASP in Action 2",
                 bookDescription = "Trying ASP from scratch 2",
                 Author = new Author {authourId=1, authorName = "Gerges"}
             },
            new Book
             {
                 bookId = 3,
                 bookName = "ASP in Action 3",
                 bookDescription = "Trying ASP from scratch 3",
                 Author = new Author {authourId=1, authorName = "Gerges"}
             }
        };
    }
    public void Add(Book entity)
    {
        entity.bookId = books.Max(b => b.bookId) + 1;
        books.Add(entity);
    }

    public void Delete(int id)
    {
        var book = Find(id);
        books.Remove(book);
    }

    public Book Find(int id)
    {
        var book = books.SingleOrDefault(b => b.bookId == id);
        return book;
    }

    public IList<Book> List()
    {
        return books;
    }

    public IList<Book> Search(string term)
    {
       var _books = books.Where(b => b.bookName.Contains(term)||
                b.bookDescription.Contains(term)||
                b.Author.authorName.Contains(term)).ToList();

                return _books;
    }

    public void Update(int id, Book entity)
    {
        var book = Find(id);
        book.bookId = entity.bookId;
        book.bookName = entity.bookName;
        book.bookDescription = entity.bookDescription;
        book.Author = entity.Author;
        book.imgURL = entity.imgURL;
    }
}