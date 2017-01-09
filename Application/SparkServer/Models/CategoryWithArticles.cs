using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.Models
{
    public class CategoryWithArticles
    {
        public string CategoryName { get; set; }

        public List<ArticleLink> ArticleLinks { get; set; } 
    }
}