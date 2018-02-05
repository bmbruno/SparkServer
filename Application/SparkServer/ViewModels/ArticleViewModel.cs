using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.ViewModels
{
    public class ArticleViewModel : BaseViewModel
    {

        //
        // Article Information
        //
        public int ArticleID { get; set; }

        public string ArticleUniqueURL { get; set; }

        public string ArticleTitle { get; set; }

        public string ArticleSubtitle { get; set; }

        public string Body { get; set; }

        public string SitecoreVersionShort { get; set; }

        public string SitecoreVersionLong { get; set; }

        public string SitecoreVersionDescription { get; set; }

        public string AuthurFullName { get; set; }

        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string PublishDateLong { get; set; }

        public string URL
        {
            get
            {
                return $"/article/{this.ArticleUniqueURL}";
            }
        }

        // TODO: marked for removal
        // public List<RelatedArticleViewModel> RelatedArticles { get; set; }

        public List<RelatedLinkItemViewModel> RelatedLinks { get; set; }
        
        public ArticleViewModel()
        {
            MenuSelection = Application.Enum.MainMenu.Article;
            // TODO: marked for removal
            // RelatedArticles = new List<RelatedArticleViewModel>();
            RelatedLinks = new List<RelatedLinkItemViewModel>();
        }

    }
}