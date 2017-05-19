using SparkServer.Application.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.ViewModels
{
    public class ArticleEditListViewModel : BaseViewModel
    {
        public List<ArticleListItemViewModel> ArticleList { get; set; }

        public ArticleEditListViewModel()
        {
            ArticleList = new List<ArticleListItemViewModel>();
        }
    }
}