using Markdig;

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

        public static string MarkdownToHTML(string markdownInput)
        {
            string output = Markdown.ToHtml(markdownInput);

            return output;
        }
    }
}