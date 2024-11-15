namespace FandomWiki.Database {

    public class CommunityRepository {

        DatabaseContext _context;

        public CommunityRepository(DatabaseContext context) {
            _context = context;
        }

        public void Add(Community community) { 
            _context.Community.Add(community);
            _context.SaveChanges();
        }

        public Community Find(int id) {
            return _context.Community.Find(id);
        }

        public IEnumerable<Community> GetAll() {
            return _context.Community;
        }
    }
}
