

namespace BookStore.Models.Repositories;
#nullable disable
public class AuthorDbRepo : IBookStoreRepository<Author>
{

    DataContext dc;

    public AuthorDbRepo(DataContext dc)
    {
        this.dc = dc;
    }
    public void Add(Author entity)
    {
        dc.Author.Add(entity);
        Commit();
    }

    public void Delete(int id)
    {
        var _author = Find(id);
       dc.Author.Remove(_author);

       Commit();
    }

    public Author Find(int id)
    {
       return dc.Author.SingleOrDefault(a=> a.authourId == id);
      
    }

    public IList<Author> List()
    {
      return dc.Author.ToList();



    }

    public IList<Author> Search(string term)
    {
        return dc.Author.Where(a => a.authorName.Contains(term)).ToList();
    }

    public void Update(int id, Author entity)
    {
      dc.Author.Update(entity);

      Commit();
    }

    
    
    private void Commit() => dc.SaveChanges();
}