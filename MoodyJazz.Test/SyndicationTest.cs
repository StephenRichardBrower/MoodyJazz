using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodyJazz.Lib;

namespace MoodyJazz.Test
{
    [TestClass]
    public class SyndicationTest
    {
        [TestMethod]
        public void TestSyndicationParsing()
        {
            var model = new Model();
            var feed = model.SyndicateUrlFeed("https://feed.pippa.io/public/shows/5d137ece8b774eb816199f63");
            model.IterateFeed(feed);
        }

        [TestMethod]
        public void TestSyndicationFromFile()
        {
            var model = new Model();
            var feed = model.SyndicateFileFeed("D:\\checkout\\sample\\giantbomb.xml");
            model.IterateFeed(feed);
        }
    }
}
