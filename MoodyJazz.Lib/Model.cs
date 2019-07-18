using System.ServiceModel.Syndication;
using System.Xml;

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
        /// and component <see cref="EpisodeModel"/>s.
        /// </summary>
        /// <param name="rssUrl"></param>
        internal void IterateFeed(string rssUrl)
        {
            XmlReader reader = XmlReader.Create(rssUrl);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            foreach (SyndicationItem item in feed.Items)
            {
                string subject = item.Title.Text;
                string summary = item.Summary.Text;      
            }
        }
    }
}
