using BookshopApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookshopApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }
    }
}
