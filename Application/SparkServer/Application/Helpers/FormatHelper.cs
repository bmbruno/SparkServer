using HeyRed.MarkdownSharp;

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
            Markdown markdown = new Markdown();
            markdown.AllowTargetBlank = true;
            markdown.AddExtension(new SparkMarkdownExtension());
            
            string output = markdown.Transform(markdownInput);

            return output;
        }
    }
}