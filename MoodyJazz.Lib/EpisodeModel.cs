using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel.Syndication;
using System.Xml.Linq;

[assembly: InternalsVisibleTo("MoodyJazz.Test")]
namespace MoodyJazz.Lib
{
    /// <summary>
    /// Encapsulation of a single episode within a feed.
    /// </summary>
    internal sealed class EpisodeModel
    {
        /// <summary>
        /// Represents a single episode parsed from a stream.
        /// </summary>
        /// <param name="baseItem"></param>
        internal EpisodeModel(SyndicationItem baseItem)
        {
            Title = baseItem.Title.ToString();
            Description = baseItem.Summary.Text.CleanMarkup();
            PubDate = baseItem.PublishDate;
            URL = baseItem.Links.FirstOrDefault().Uri.AbsoluteUri;

            foreach (var extension in baseItem.ElementExtensions)
            {
                var ele = extension.GetObject<XElement>();

                switch (extension.OuterName)
                {
                    case "keywords":
                        KeywordString = ele.Value;
                        break;
                    case "explicit":
                        IsExplicit = ele.Value.ToLowerInvariant() == "yes";
                        break;
                    case "image":
                        ImageLink = ele.Value;
                        break;
                }
            }
        }

        /// <summary>
        /// Title for the episode.
        /// </summary>
        internal string Title { get; set; }

        /// <summary>
        /// Episode description.
        /// </summary>
        internal string Description { get; set; }

        /// <summary>
        /// Published DateTime from GMT.
        /// </summary>
        internal DateTimeOffset PubDate { get; set; }

        /// <summary>
        /// Web link to the image.
        /// </summary>
        internal string ImageLink { get; set; }

        /// <summary>
        /// Stores a list of all the keywords or tags.
        /// </summary>
        internal string KeywordString { get; set; }

        /// <summary>
        /// Episode URL location. Both used for downloading the actual episode
        /// and then as referential metadata to linkback if needed.
        /// </summary>
        internal string URL { get; set; }

        /// <summary>
        /// Path to saved audio file.
        /// </summary>
        internal string FilePath { get; set; }

        /// <summary>
        /// Itunes Explicit 
        /// </summary>
        internal bool IsExplicit { get; set; }

        /// <summary>
        /// TODO: Function that converts the <see cref="URL"/> into
        /// a stored file located at <see cref="FilePath"/>.
        /// </summary>
        /// <returns>On a successful conversion.</returns>
        internal bool Download()
        {
            FilePath = URL;
            throw new NotImplementedException();
        }
    }
}
