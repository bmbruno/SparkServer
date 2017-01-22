using SparkServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.ViewModels
{
    public class HomeIndexViewModel : BaseViewModel
    {
        public List<ArticleViewModel> ArticleList { get; set; }

        public List<BlogArticleViewModel> BlogList { get; set; }

        public HomeIndexViewModel()
        {
            ArticleList = new List<ArticleViewModel>();
            BlogList = new List<BlogArticleViewModel>();
        }
    }
}