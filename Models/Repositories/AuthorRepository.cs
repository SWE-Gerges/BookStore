namespace BookStore.Models.Repositories;
#nullable disable

public class AuthorRepository : IBookStoreRepository<Author>
{

   public List<Author> authors;

    public AuthorRepository()
    {
        authors = new List<Author>(){
        new Author{
            authourId=1, authorName = "Gerges"
        },

        new Author{
            authourId = 2, authorName = "BoB"
        },

        new Author{
            authourId = 3, authorName = "TEsT"
        }
    };
    }



    public void Add(Author entity)
    {
        entity.authourId = authors.Max(a => a.authourId)+1;
        authors.Add(entity);
    }

    public void Delete(int id)
    {
        var author = Find(id);
        authors.Remove(author);
        // authors.Remove(Find(id)); --> another, onestep less, way but I find it less readable
    }

    public Author Find(int id)
    {
        var author = authors.Single(a => a.authourId == id);
        return author;
    }

    public IList<Author> List()
    {
        return authors;
    }

    public IList<Author> Search(string term)
    {
        return authors.Where(a => a.authorName.Contains(term)).ToList();
    }

    public void Update(int id, Author entity)
    {
        var author = Find(id);
        author.authorName = entity.authorName;
        author.authourId = entity.authourId;
    }
}