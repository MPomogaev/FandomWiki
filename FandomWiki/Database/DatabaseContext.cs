using Microsoft.EntityFrameworkCore;

namespace FandomWiki.Database
{
    public class DatabaseContext: DbContext {

        DbSet<Community> Community { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=FandomWiki;Username=postgres;Password=root");
        }
    }
}
