using SparkServer.Data;
using SparkServer.Models;
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

        public static void MapToViewModel(this CategoryListViewModel vm, IEnumerable<Category> categories, IEnumerable<Article> articles)
        {
            foreach (Category category in categories)
            {
                CategoryWithArticles cwa = new CategoryWithArticles();

                // TODO: add OrderBy sort for article list
                var articlesForCategory = articles.Where(u => u.CategoryID == category.ID);

                cwa.CategoryName = category.Name;

                foreach (Article article in articlesForCategory)
                {
                    cwa.ArticleLinks.Add(new ArticleLink() {
                        ArticleID = article.ID,
                        ArticleTitle = article.Title,
                        URL = $"/Article/{article.UniqueURL}"
                    });
                }
            }
        }
    }
}