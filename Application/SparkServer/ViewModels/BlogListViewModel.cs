using SparkServer.Application.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.ViewModels
{
    public class BlogListViewModel
    {
        public List<BlogArticleViewModel> BlogList{ get; set; }

        public string Year { get; set; }

        public string Month { get; set; }

        public ViewMode ViewMode { get; set; }

        public BlogListViewModel()
        {
            BlogList = new List<BlogArticleViewModel>();
        }
    }
}