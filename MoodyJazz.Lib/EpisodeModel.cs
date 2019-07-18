namespace MoodyJazz.Lib
{
    /// <summary>
    /// Encapsulation of a single episode within a feed.
    /// </summary>
    internal sealed class EpisodeModel
    {
        /// <summary>
        /// Title for the episode.
        /// </summary>
        internal string Title { get; set; }

        /// <summary>
        /// Episode description.
        /// </summary>
        internal string Description { get; set; }

        /// <summary>
        /// Episode published date.
        /// TODO: Probably convert to a datetime? See how ID3 handles this.
        /// </summary>
        internal string PublishedDateString { get; set; }

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
        /// TODO: Function that converts the <see cref="URL"/> into
        /// a stored file located at <see cref="FilePath"/>.
        /// </summary>
        /// <returns>On a successful conversion.</returns>
        internal bool Download()
        {
            FilePath = URL;
            return false;
        }
    }
}
