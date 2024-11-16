using FandomWiki.Database;
using FandomWiki.Pages;

namespace Tests {
    public class CommunityTest {
        private CommunityRepository GetTestRepository() {
            return new(TestDatabase.GetTestDatabase());
        }

        [Fact]
        public void AddCommunityToDatabase() {
            var rep = GetTestRepository();
            Community newCommunity = new() { Name = "test1", Description = "test1" };
            rep.Add(newCommunity);
            Assert.Equal(1, newCommunity.Id);
            newCommunity = new() { Name = "test2", Description = "test2" };
            rep.Add(newCommunity);
            Assert.Equal(2, newCommunity.Id);
            newCommunity = new() { Name = "test3", Description = "test3" };
            rep.Add(newCommunity);
            Assert.Equal(3, newCommunity.Id);
        }

        [Fact]
        public void GetAllCommunity() {
            var rep = GetTestRepository();
            rep.Add(new() { Name = "name1", Description = "descr1" });
            rep.Add(new() { Name = "name2", Description = "descr2" });
            rep.Add(new() { Name = "name3", Description = "descr3" });
            var communities = rep.GetAll().ToList();
            Assert.Equal(3, communities.Count);
            for (int i = 0; i < communities.Count; i++) {
                var community = communities[i];
                Assert.Equal("name" + (i + 1), community.Name);
                Assert.Equal("descr" + (i + 1), community.Description);
            }
        }

        [Fact]
        public void FindExistingCommunityById() {
            var rep = GetTestRepository();
            rep.Add(new() { Name = "testName", Description = "testDescription" });
            var community = rep.Find(1);
            Assert.NotNull(community);
            Assert.Equal("testName", community.Name);
            Assert.Equal("testDescription", community.Description);
        }

        [Fact]
        public void FindNoneExistingCommunityById() {
            var rep = GetTestRepository();
            rep.Add(new() { Name = "test1", Description = "test1" });
            var community = rep.Find(2);
            Assert.Null(community);
        }

        [Fact]
        public void FindExistingCommunityByName() {
            var rep = GetTestRepository();
            rep.Add(new() { Name = "1test", Description = "test1" });
            rep.Add(new() { Name = "123test", Description = "test2" });
            rep.Add(new() { Name = "12test", Description = "test3" });
            var firstSearch = rep.Search("1").ToList();
            Assert.NotNull(firstSearch);
            Assert.Equal(firstSearch.Count, 3);
            var secondSearch = rep.Search("123").ToList();
            Assert.NotNull(secondSearch);
            Assert.Equal(secondSearch.Count, 1);
            var community = secondSearch.First();
            Assert.Equal(community.Name, "123test");
            Assert.Equal(community.Description, "test2");
        }

        [Fact]
        public void CreateCommunityPost() {
            var rep = GetTestRepository();
            var page = new CreateCommunityModel(null, rep);
            page.Name = "name";
            page.Description = "descr";
            page.OnPost();
            var community = rep.Find(1);
            Assert.NotNull(community);
            Assert.Equal("name", community.Name);
            Assert.Equal("descr", community.Description);
        }

    }
}