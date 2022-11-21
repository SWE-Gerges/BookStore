
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models.Repositories;
#nullable disable
public class BookDbRepo : IBookStoreRepository<Book>
{
    DataContext dc;
    public BookDbRepo(DataContext dc)
    {
        this.dc = dc;
    }


    public void Add(Book entity)
    {
        dc.Book.Add(entity);

        Commit();
    }

    public void Delete(int id)
    {
        var _book = Find(id);
        dc.Book.Remove(_book);

        Commit();
    }

    public Book Find(int id)
    {
        var _book = dc.Book.Include(a => a.Author).SingleOrDefault(b => b.bookId == id);
        return _book;
    }

    public IList<Book> List()
    {
        return dc.Book.Include(a => a.Author).ToList();
    }

    public IList<Book> Search(string term)
    {
       var _books = dc.Book.Include(a => a.Author).Where
       (b => b.bookName.Contains(term)||
       b.bookDescription.Contains(term)||
       b.Author.authorName.Contains(term)).ToList();

        

       return _books;
    }

    public void Update(int id, Book entity)
    {
        dc.Book.Update(entity);

        Commit();
    }


    private void Commit() => dc.SaveChanges();
}