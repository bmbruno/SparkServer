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
            vm.SitecoreVersionShort = (model.SitecoreVersion != null) ? model.SitecoreVersion.Version : string.Empty;
            vm.SitecoreVersionLong = (model.SitecoreVersion != null) ? $"{model.SitecoreVersion.Version} rev. {model.SitecoreVersion.Revision}" : string.Empty;
            vm.SitecoreVersionDescription = (model.SitecoreVersion != null) ? model.SitecoreVersion.Description : string.Empty;
            vm.AuthurFullName = (model.Author != null) ? $"{model.Author.FirstName} {model.Author.LastName}" : string.Empty;
            vm.CategoryID = model.CategoryID;
            vm.CategoryName = (model.Category != null) ? model.Category.Name : string.Empty;
        }
    }
}