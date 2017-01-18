﻿using System;
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

        public string UniqueURL { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string AuthorFullName { get; set; }

        public DateTime PublishDate { get; set; }

        // TODO: add blog tags
        
    }
}