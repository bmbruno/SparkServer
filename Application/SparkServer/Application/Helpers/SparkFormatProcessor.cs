using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.Application.Helpers
{
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
    }
}