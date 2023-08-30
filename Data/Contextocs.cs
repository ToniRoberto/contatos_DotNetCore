using Microsoft.EntityFrameworkCore;
using WebApplicationDB.Models;

namespace WebApplicationDB.Data
{
    public class Contextocs : DbContext
    {
        public Contextocs(DbContextOptions<Contextocs> options) 
            : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
