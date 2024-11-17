using Microsoft.EntityFrameworkCore;

namespace FandomWiki.Database {
    public class DatabaseContext: DbContext {

        public DbSet<Community> Community { get; set; }
        public DbSet<Repository> Repositories { get; set; }
        public DbSet<Article> Articles { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Repository>()
                .HasMany(r => r.Children)
                .WithOne(r => r.Parent);
            modelBuilder.Entity<Repository>()
                .HasMany(r => r.Articles)
                .WithOne(a => a.Parent);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    }
}
