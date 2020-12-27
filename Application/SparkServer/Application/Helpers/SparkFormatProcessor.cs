using HtmlAgilityPack;

namespace SparkServer.Application.Helpers
{
    /// <summary>
    /// Handles processing of HTML formatters.
    /// </summary>
    public static class SparkFormatProcessor
    {
        /// <summary>
        /// Adds target="_blank" attribute to all anchor tags that reference resources external to the domain name configured in AppSettings (use Config.DomainName in code to get at the value).
        /// </summary>
        /// <param name="htmlDoc">HtmlAgilityPack HtmlDocument object.</param>
        /// <returns>HtmlDocument object with anchor tags processed.</returns>
        public static HtmlDocument ExternalLinksGetBlankTarget(HtmlDocument htmlDoc)
        {
            var anchors = htmlDoc.DocumentNode.SelectNodes("//a");

            if (anchors == null)
                return htmlDoc;

            foreach (var anchor in anchors)
            {
                string originalHTML = anchor.OuterHtml;

                if (anchor.Attributes["href"] != null)
                {
                    string anchorValue = anchor.Attributes["href"].Value;

                    if (!anchorValue.Contains(Config.DomainName) && !anchorValue.StartsWith("/"))
                    {
                        if (anchor.Attributes["target"] == null)
                        {
                            anchor.SetAttributeValue("target", "_blank");
                        }
                    }
                }
            }

            return htmlDoc;
        }

        /// <summary>
        /// Adds DIV with class of "figure" around standalone images. Markdown conversion will create "p/img", and this will convert that to "div/img".
        /// </summary>
        /// <param name="htmlDoc">HtmlAgilityPack HtmlDocument object.</param>
        /// <returns>HtmlDocument object with anchor tags processed.</returns>
        public static HtmlDocument FrameImagesWithFigure(HtmlDocument htmlDoc)
        {
            var images = htmlDoc.DocumentNode.SelectNodes("//img");

            if (images == null)
                return htmlDoc;

            foreach (var image in images)
            {
                if (image.ParentNode.Name.Equals("p"))
                {
                    image.ParentNode.Name = "div";
                    image.ParentNode.AddClass("figure full");
                }

                if (image.ParentNode.Name.Equals("a") && image.ParentNode.ParentNode.Name.Equals("p"))
                {
                    image.ParentNode.ParentNode.Name = "div";
                    image.ParentNode.ParentNode.AddClass("figure full");
                }
            }

            return htmlDoc;
        }
    }
}