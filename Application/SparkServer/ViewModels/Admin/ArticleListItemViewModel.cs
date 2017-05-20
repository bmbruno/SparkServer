using SparkServer.Application.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.ViewModels
{
    public class ArticleListItemViewModel : BaseViewModel
    { 
        public int ID { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string CategoryName { get; set; }

        public int CategorySortOrder { get; set; }

        public string SitecoreVersion { get; set; }

        public string PublishedDate { get; set; }

        public string AuthorName { get; set; }
    }
}