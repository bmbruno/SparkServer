using SparkServer.Application.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.ViewModels
{
    public class BlogEditListViewModel : BaseViewModel
    {
        public List<BlogListItemViewModel> BlogList { get; set; }

        public BlogEditListViewModel()
        {
            BlogList = new List<BlogListItemViewModel>();
        }
    }
}