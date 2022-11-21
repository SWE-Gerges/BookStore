using BookStore.Models;
namespace BookStore.ViewModels;
#nullable disable
public class BookAuthorViewModel
{
    public int bookId { get; set; }
    public string bookName { get; set; }
    public string bookDescription { get; set; }

    public int authorID { get; set; }
    public IFormFile file { get; set; }
    public IList<Author> Authors { get; set; }
    public string imgURL { get; set; }
}
