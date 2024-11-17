namespace FandomWiki.Database {
    public class Article {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public Repository Parent { get; set; }
    }
}
