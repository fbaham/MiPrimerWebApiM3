using Microsoft.EntityFrameworkCore;
using MiPrimerWebApiM3.Entities;

namespace MiPrimerWebApiM3.Contexts {
    public class ApplicationDbContext : DbContext { 
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base (options) { }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books {get; set;}
    }
}