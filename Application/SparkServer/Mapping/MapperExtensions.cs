using SparkServer.Data;
using SparkServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.Mapping
{
    public static class MapperExtensions
    {
        public static void MapToViewModel(this ArticleViewModel vm, Article model)
        {
            vm.ArticleID = model.ID;
            vm.ArticleUniqueURL = model.UniqueURL;
            vm.ArticleTitle = model.Title;
            vm.Body = model.Body;
            vm.SitecoreVersionShort = model.SitecoreVersion.Version;
            vm.SitecoreVersionLong = $"{model.SitecoreVersion.Version} rev. {model.SitecoreVersion.Revision}";
            vm.SitecoreVersionDescription = model.SitecoreVersion.Description;
            vm.AuthurFullName = $"{model.Author.FirstName} {model.Author.LastName}";
            vm.CategoryID = model.CategoryID;
            vm.CategoryName = model.Category.Name;
        }
    }
}