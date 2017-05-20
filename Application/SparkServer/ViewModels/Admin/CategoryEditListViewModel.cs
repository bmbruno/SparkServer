using SparkServer.Application.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.ViewModels
{
    public class CategoryEditListViewModel : BaseViewModel
    {
        public List<CategoryListItemViewModel> CategoryList { get; set; }

        public CategoryEditListViewModel()
        {
            CategoryList = new List<CategoryListItemViewModel>();
        }
    }
}