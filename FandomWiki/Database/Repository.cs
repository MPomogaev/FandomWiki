namespace FandomWiki.Database {
    public class Repository {
        public int Id { get; set; }
        public string Name { get; set; }
        public Repository Parent { get; set; }
        public List<Repository> Children { get; set; } = new();
        public List<Article> Articles { get; set; } = new();
    }
}
