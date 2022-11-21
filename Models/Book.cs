namespace BookStore.Models;

#nullable disable
public class Book
{
    public int bookId { get; set; }
    public string bookName { get; set; }
    public string bookDescription { get; set; }
    public string imgURL { get; set; }

    // public int authorId { get; set; }
    public Author Author { get; set; }
}
