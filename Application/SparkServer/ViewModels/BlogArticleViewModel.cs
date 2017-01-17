using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.ViewModels
{
    public class BlogArticleViewModel
    {
        //
        // Article Information
        //

        public int BlogID { get; set; }

        public string ArticleUniqueURL { get; set; }

        public string ArticleTitle { get; set; }

        public string Body { get; set; }

        public string AuthorFullName { get; set; }

        // TODO: add blog tags
        
    }
}