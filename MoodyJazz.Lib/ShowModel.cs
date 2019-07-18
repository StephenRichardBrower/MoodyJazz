namespace MoodyJazz.Lib
{
    using System.Collections.Generic;

    /// <summary>
    /// Encapsulation of an entire show, represented wholly within one RSS feed XML,
    /// so this file will often consume the 'headers' and then iterate down into
    /// the contained 'items.'
    /// </summary>
    internal sealed class ShowModel
    {
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
