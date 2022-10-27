using Microsoft.EntityFrameworkCore;
using trackingapi.Models;

namespace trackingapi.Data
{
    public class LibraryDbContext:DbContext
    {
        public DbSet<Library> Libraries { get; set; }
        public LibraryDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}
