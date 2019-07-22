using System;
using System.IO;
using System.Net;
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
            Title = baseItem.Title.Text;
            Description = baseItem.Summary.Text.CleanMarkup();
            PubDate = baseItem.PublishDate;

            foreach (var link in baseItem.Links)
            {
                var uri = link.GetAbsoluteUri();
                // Check if we have an actual audio file. If not... store it.
                if (link.RelationshipType == "enclosure")
                {
                    Permalink = link.Uri.ToString();
                    Extension = Path.GetExtension(Permalink).Substring(0,4);
                    FileName = $"X. {Title}{Extension}";
                }
                else
                {
                    DisplayLink = uri.AbsoluteUri;
                }
            }

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
        internal string DisplayLink { get; set; }

        /// <summary>
        /// Link to item on-server.
        /// </summary>
        internal string Permalink { get; set; }

        /// <summary>
        /// Path to saved audio file.
        /// </summary>
        internal string FilePath { get; set; }

        /// <summary>
        /// Extension of the audio.
        /// </summary>
        internal string Extension { get; set; }

        /// <summary>
        /// Itunes Explicit 
        /// </summary>
        internal bool IsExplicit { get; set; }

        /// <summary>
        /// Stores the name of the file (not PATH).
        /// </summary>
        internal string FileName { get; set; }

        /// <summary>
        /// TODO: Function that converts the <see cref="URL"/> into
        /// a stored file located at <see cref="FilePath"/>.
        /// </summary>
        /// <returns>On a successful conversion.</returns>
        internal bool Download()
        {
            string path = Path.GetTempPath();
            FilePath = $"{path}\\{FileName}";

            using (var client = new WebClient())
            {
                client.DownloadFile(Permalink, FilePath);
            }

            return true;
        }
    }
}
