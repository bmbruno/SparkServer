using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.ViewModels
{
    public class RelatedArticleViewModel : BaseViewModel
    {
        public int RelatedArticleID { get; set; }

        public string Title { get; set; }

        public string URL { get; set; }

        public RelatedArticleViewModel()
        {
            
        }

    }
}