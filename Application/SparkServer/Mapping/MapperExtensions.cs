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
        /// <summary>
        /// Database object -> ArticleViewModel.
        /// </summary>
        /// <param name="vm">ArticleViewModel.</param>
        /// <param name="model">Article object.</param>
        public static void MapToViewModel(this ArticleViewModel vm, Article article)
        {
            vm.ArticleID = article.ID;
            vm.ArticleUniqueURL = article.UniqueURL;
            vm.ArticleTitle = article.Title;
            vm.Body = article.Body;
            vm.SitecoreVersionShort = (article.SitecoreVersion != null) ? article.SitecoreVersion.Version : string.Empty;
            vm.SitecoreVersionLong = (article.SitecoreVersion != null) ? $"{article.SitecoreVersion.Version} rev. {article.SitecoreVersion.Revision}" : string.Empty;
            vm.SitecoreVersionDescription = (article.SitecoreVersion != null) ? article.SitecoreVersion.Description : string.Empty;
            vm.AuthurFullName = (article.Author != null) ? $"{article.Author.FirstName} {article.Author.LastName}" : string.Empty;
            vm.CategoryID = article.CategoryID;
            vm.CategoryName = (article.Category != null) ? article.Category.Name : string.Empty;
            vm.PublishDateLong = $"{article.PublishDate.Value.ToString("MMMM")} {article.PublishDate.Value.Year.ToString()}";
        }

        /// <summary>
        /// Database objects -> CategoryListViewModel.
        /// </summary>
        /// <param name="vm">CategoryListViewModel</param>
        /// <param name="categories">Enumerable of Category objects.</param>
        /// <param name="articles">Enumerable of Article objects.</param>
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

                vm.CategoriesList.Add(cwa);
            }
        }

        /// <summary>
        /// Database objects -> BlogListViewModel
        /// </summary>
        /// <param name="vm">BlogListViewModel</param>
        /// <param name="blogs">IEnumerable of Blog objects.</param>
        public static void MapToViewModel(this BlogListViewModel vm, IEnumerable<Blog> blogs)
        {
            foreach (var blog in blogs)
            {
                BlogArticleViewModel blogVM = new BlogArticleViewModel();
                blogVM.MapToViewModel(blog);
                vm.BlogList.Add(blogVM);
            }
        }

        /// <summary>
        /// Database object -> BlogArticleViewModel.
        /// </summary>
        /// <param name="vm">BlogArticleViewModel</param>
        /// <param name="blog">Blog object</param>
        public static void MapToViewModel(this BlogArticleViewModel vm, Blog blog)
        {
            vm.BlogID = blog.ID;
            vm.Title = blog.Title;
            vm.Body = blog.Body;
            vm.ImagePath = blog.ImagePath;
            vm.ImageThumbnailPath = blog.ImageThumbnailPath;
            vm.AuthorFullName = (blog.Author != null) ? $"{blog.Author.FirstName} {blog.Author.LastName}" : string.Empty;
            vm.UniqueURL = blog.UniqueURL;
            vm.PublishDate = blog.PublishDate.Value;
        }

        /// <summary>
        /// Database objects -> HomeViewModel.
        /// </summary>
        /// <param name="vm">HomeViewModel</param>
        /// <param name="articles"></param>
        /// <param name="blogs"></param>
        public static void MapToViewModel(this HomeViewModel vm, IEnumerable<Article> articles, IEnumerable<Blog> blogs)
        {
            foreach (var article in articles)
            {
                ArticleViewModel articleVM = new ArticleViewModel();
                articleVM.MapToViewModel(article);
                vm.ArticleList.Add(articleVM);
            }

            foreach (var blog in blogs)
            {
                BlogArticleViewModel blogVM = new BlogArticleViewModel();
                blogVM.MapToViewModel(blog);
                vm.BlogList.Add(blogVM);
            }
        }
    }
}