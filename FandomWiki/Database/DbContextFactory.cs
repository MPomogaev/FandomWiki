using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace FandomWiki.Database {
    public class DbContextFactory : IDesignTimeDbContextFactory<DatabaseContext> {
        public DatabaseContext CreateDbContext(string[] args) {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            var host = Host.CreateDefaultBuilder().Build();
            var config = host.Services.GetRequiredService<IConfiguration>();
            optionsBuilder.UseNpgsql(config.GetConnectionString("FandomWiki"));
            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}
