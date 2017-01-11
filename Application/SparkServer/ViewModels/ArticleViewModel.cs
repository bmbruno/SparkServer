﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.ViewModels
{
    public class ArticleViewModel
    {

        //
        // Article Information
        //
        public int ArticleID { get; set; }

        public string ArticleUniqueURL { get; set; }

        public string ArticleTitle { get; set; }

        public string Body { get; set; }

        public string SitecoreVersionShort { get; set; }

        public string SitecoreVersionLong { get; set; }

        public string SitecoreVersionDescription { get; set; }

        public string AuthurFullName { get; set; }

        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        // TODO: related articles - List<RelatedArticleViewModel>()

        // TODO: related links - List<RelatedLinkViewModel>()
        
    }
}