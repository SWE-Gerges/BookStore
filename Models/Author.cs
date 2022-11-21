using System.ComponentModel.DataAnnotations;
namespace BookStore.Models;

#nullable disable
public class Author
{
    [Key]
    public int authourId { get; set; }
    public string authorName { get; set; }
}
