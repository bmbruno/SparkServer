using SparkServer.Application.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.ViewModels
{
    public class BlogTagEditListViewModel : BaseViewModel
    {
        public List<BlogTagListItemViewModel> BlogTagList { get; set; }

        public BlogTagEditListViewModel()
        {
            BlogTagList = new List<BlogTagListItemViewModel>();
        }
    }
}