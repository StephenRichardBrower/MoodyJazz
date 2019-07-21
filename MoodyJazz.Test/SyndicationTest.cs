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

        [TestMethod]
        public void CanParseBareMinimum()
        {
            var model = new Model();
            var feed = model.SyndicateFileFeed("D:\\checkout\\sample\\giantbomb.xml");
            var show = model.IterateFeed(feed);

            Assert.IsTrue(_hasUsefulContents(show.Title));
            Assert.IsTrue(_hasUsefulContents(show.Description));

            foreach (var ep in show.Items)
            {
                Assert.IsTrue(_hasUsefulContents(ep.Title));
                Assert.IsTrue(_hasUsefulContents(ep.Description));
                Assert.IsTrue(_hasUsefulContents(ep.URL));
            }
        }

        /// <summary>
        /// Helper test function.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private bool _hasUsefulContents(string content)
        {
            return !string.IsNullOrEmpty(content) && content.Length > 3;
        }
    }
}
