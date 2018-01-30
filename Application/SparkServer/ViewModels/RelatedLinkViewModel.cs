using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.ViewModels
{
    public class RelatedLinkViewModel : BaseViewModel
    {
        public int RelatedArticleID { get; set; }

        public string Name { get; set; }

        public string URL { get; set; }

        public RelatedLinkViewModel()
        {
            
        }
    }
}