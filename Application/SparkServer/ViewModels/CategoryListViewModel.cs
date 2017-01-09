using SparkServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.ViewModels
{
    public class CategoryListViewModel
    {
        public List<CategoryWithArticles> CategoriesList { get; set; }
    }
}