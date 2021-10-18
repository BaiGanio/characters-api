using Microsoft.EntityFrameworkCore;

namespace Api
{
    
   public class CharactersDbContext : DbContext
    {
        public CharactersDbContext(DbContextOptions<CharactersDbContext> options)
          : base(options) { }

        public DbSet<Character> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
