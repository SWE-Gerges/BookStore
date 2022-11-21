using BookStore.Models;
using Microsoft.EntityFrameworkCore;


#nullable disable
public class DataContext : DbContext{
    
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    public DbSet<Author> Author { get; set; }
    public DbSet<Book> Book { get; set; }
}