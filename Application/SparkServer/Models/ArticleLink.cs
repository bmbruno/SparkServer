using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.Models
{
    public class ArticleLink
    {
        public int ArticleID { get;set;}

        public string ArticleTitle { get; set; }

        public string URL { get; set; }
    }
}