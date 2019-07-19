using HtmlAgilityPack;

namespace MoodyJazz.Lib
{
    /// <summary>
    /// Extension bucket.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Tidies away HTML markup from a string, converting to plaintext.
        /// </summary>
        /// <param name="str">This string.</param>
        /// <returns>A cleaner HTML-cleaned string.</returns>
        public static string CleanMarkup(this string str)
        {
            HtmlDocument mainDoc = new HtmlDocument();
            string htmlString = str;
            mainDoc.LoadHtml(htmlString);
            return mainDoc.DocumentNode.InnerText;
        }
    }
}
