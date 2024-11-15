using FandomWiki.Database;
using Microsoft.EntityFrameworkCore;

namespace Tests {
    public class TestDatabase {
        const string connectionStr = "Host=localhost;Port=5432;Database=TestFandomWiki;Username=postgres;Password=root";

        public static DatabaseContext GetTestDatabase() {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseNpgsql(connectionStr)
                .Options;

            DatabaseContext context = new DatabaseContext(options);
            context.Database.EnsureDeleted();
            Assert.True(context.Database.EnsureCreated());
            return context;
        }
    }
}
