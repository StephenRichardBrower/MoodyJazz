using System.IO;
using System.Runtime.CompilerServices;
using System.ServiceModel.Syndication;
using System.Xml;

[assembly: InternalsVisibleTo("MoodyJazz.Test")]
namespace MoodyJazz.Lib
{
    /// <summary>
    /// Current 'main' of the Moody Jazz library.
    /// </summary>
    internal sealed class Model
    {
        /// <summary>
        /// TODO: Function for reading a RSS feed and turning 
        /// it into a consumable amount of a <see cref="ShowModel"/>
        /// and component <see cref="EpisodeModel"/> s.
        /// </summary>
        /// <param name="rssUrl"></param>
        public void IterateFeed(SyndicationFeed feed)
        {
            var show = new ShowModel(feed);
            foreach (SyndicationItem item in feed.Items)
            {
                show.Items.Add(new EpisodeModel(item));
            }
        }

        /// <summary>
        /// Turns a Url Feed into a SyndicationFeed.
        /// </summary>
        /// <param name="feedUrl">Web URL of a feed.</param>
        /// <returns>Open SyndicationFeed.</returns>
        public SyndicationFeed SyndicateUrlFeed(string feedUrl)
        {
            XmlReader reader = XmlReader.Create(feedUrl);
            return SyndicationFeed.Load(reader);
        }

        /// <summary>
        /// Turns an xml file into a SyndicationFeed.
        /// </summary>
        /// <param name="xmlFilePath">Local file path of a feed.</param>
        /// <returns>Open SyndicationFeed.</returns>
        public SyndicationFeed SyndicateFileFeed(string xmlFilePath)
        {
            string xmlString = File.ReadAllText(xmlFilePath);
            TextReader tr = new StringReader(xmlString);
            XmlReader xmlReader = XmlReader.Create(tr);
            return SyndicationFeed.Load(xmlReader);
        }
    }
}
