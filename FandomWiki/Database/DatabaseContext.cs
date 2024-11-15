using Microsoft.EntityFrameworkCore;

namespace FandomWiki.Database {
    public class DatabaseContext: DbContext {

        public DbSet<Community> Community { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        }
    }
}
