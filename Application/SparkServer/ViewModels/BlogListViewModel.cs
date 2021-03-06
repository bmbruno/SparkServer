﻿using SparkServer.Application.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.ViewModels
{
    public class BlogListViewModel : BaseViewModel
    {
        public List<BlogArticleViewModel> BlogList { get; set; }

        public List<BlogTagViewModel> BlogTagList { get; set; }

        public string Header { get; set; }

        public BlogListViewModel()
        {
            BlogList = new List<BlogArticleViewModel>();
            BlogTagList = new List<BlogTagViewModel>();
            MenuSelection = MainMenu.Blog;
        }
    }
}