using HeyRed.MarkdownSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.Application
{
    public class SparkMarkdownExtension : IMarkdownExtension
    {
        public string Transform(string text)
        {
            return text;
        }
    }
}