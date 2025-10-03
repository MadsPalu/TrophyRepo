using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aflevering1;

namespace Aflevering1Test
{
    [TestClass]
    public class TrophyRepo_SimpleTests
    {
        private TrophyRepo repo;

        [TestInitialize]
        public void Setup() => repo = new TrophyRepo();

        private Trophy Make(string comp = "CupA", int year = 2000)
            => new Trophy { Competition = comp, Year = year };

        ///Add: assigns unique, incrementing Ids.
        [TestMethod]
        public void Add_AssignsIncrementingIds()
        {
            var t1 = repo.Add(Make("CupA", 1970));
            var t2 = repo.Add(Make("CupB", 1980));
            var t3 = repo.Add(Make("CupC", 1990));

            Assert.AreEqual(t1.Id + 1, t2.Id);
            Assert.AreEqual(t2.Id + 1, t3.Id);
        }

        ///GetById: returns the stored trophy when it exists.
        [TestMethod]
        public void GetById_Found_ReturnsItem()
        {
            var added = repo.Add(Make("LeagueCup", 1995));
            var fetched = repo.GetById(added.Id);

            Assert.IsNotNull(fetched);
            Assert.AreEqual(added.Id, fetched!.Id);
            Assert.AreEqual("LeagueCup", fetched.Competition);
            Assert.AreEqual(1995, fetched.Year);
        }

        ///GetById: returns null for unknown id.
        [TestMethod]
        public void GetById_NotFound_ReturnsNull()
        {
            Assert.IsNull(repo.GetById(9999));
        }

        ///Remove: deletes and returns the trophy when found.
        [TestMethod]
        public void Remove_Found_RemovesAndReturns()
        {
            var added = repo.Add(Make("CityCup", 2010));

            var removed = repo.Remove(added.Id);

            Assert.IsNotNull(removed);
            Assert.AreEqual(added.Id, removed!.Id);
            Assert.IsNull(repo.GetById(added.Id));
        }

        ///Remove: returns null for unknown id and leaves repo unchanged.
        [TestMethod]
        public void Remove_NotFound_ReturnsNull()
        {
            var keep = repo.Add(Make("KeepCup", 2001));

            var result = repo.Remove(123456);

            Assert.IsNull(result);
            Assert.IsNotNull(repo.GetById(keep.Id));
        }
    }
}
