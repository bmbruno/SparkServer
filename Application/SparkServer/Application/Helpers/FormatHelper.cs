using Markdig;
using HtmlAgilityPack;
using System.IO;

namespace SparkServer.Application.Helpers
{
    public static class FormatHelper
    {
        /// <summary>
        /// Turns a proper phrase/sentence into URL-friendly format. "Hello, Great Big World" -> "hello-great-big-world"
        /// </summary>
        /// <param name="input">Input string to transform.</param>
        /// <returns>URL-ready string.</returns>
        public static string ConvertToUrlFormat(string input)
        {
            input = input.ToLower();
            input = input.Replace(" ", "-");

            return "";
        }

        /// <summary>
        /// Converts a string of Markdown to valid HTML for hosting 
        /// </summary>
        /// <param name="markdownInput"></param>
        /// <returns></returns>
        public static string MarkdownToHTML(string markdownInput)
        {           
            string htmlValue = Markdown.ToHtml(markdownInput);

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlValue);

            htmlDoc = SparkFormatProcessor.ExternalLinksGetBlankTarget(htmlDoc);

            // TODO: images: a) if image tag is not proceeded by a <div> with class of "figure", add "figure" div; b) if image is proceeded by a <div> with class "figure", then ignore and move on
            
            return htmlDoc.DocumentNode.OuterHtml;
        }
    }
}