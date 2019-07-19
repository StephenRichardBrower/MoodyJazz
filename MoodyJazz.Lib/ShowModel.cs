using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.ServiceModel.Syndication;

[assembly: InternalsVisibleTo("MoodyJazz.Test")]
namespace MoodyJazz.Lib
{
    /// <summary>
    /// Encapsulation of an entire show, represented wholly within one RSS feed XML,
    /// so this file will often consume the 'headers' and then iterate down into
    /// the contained 'items.'
    /// </summary>
    internal sealed class ShowModel
    {
        /// <summary>
        /// Constructs a new Show Model based on a feed.
        /// </summary>
        /// <param name="baseFeed"></param>
        internal ShowModel(SyndicationFeed baseFeed)
        {
            URL = baseFeed.BaseUri?.ToString();
            Title = baseFeed.Title?.Text;
            Description = baseFeed.Description?.Text.CleanMarkup();
            ImageLocation = baseFeed.ImageUrl?.ToString();
            Copyright = baseFeed.Copyright?.Text;
            Language = baseFeed.Language;
        }

        /// <summary>
        /// Generally the Show URL itself.
        /// </summary>
        internal string URL { get; set; }

        /// <summary>
        /// Formatted Show Title.
        /// </summary>
        internal string Title { get; set; }

        /// <summary>
        /// Show Description - long string.
        /// </summary>
        internal string Description { get; set; }

        /// <summary>
        /// Language of the show.
        /// </summary>
        internal string Language { get; set; }

        /// <summary>
        /// Date of the latest publish.
        /// </summary>
        internal DateTime PubDate { get; set; }

        /// <summary>
        /// Stores the Temp image location.
        /// TODO: Obvious problem here - We need to TEMP download the image to apply it to metadata.
        /// Images don't like to stay in memory...
        /// </summary>
        internal string ImageLocation { get; set; }

        /// <summary>
        /// Stores the copyright, if provided.
        /// </summary>
        internal string Copyright { get; set; }

        /// <summary>
        /// Contains the episodes or individual entries within the feed,
        /// each a fully fledged <see cref="EpisodeModel"/>.
        /// </summary>
        internal List<EpisodeModel> Items { get; set; } = new List<EpisodeModel>();
    }
}
