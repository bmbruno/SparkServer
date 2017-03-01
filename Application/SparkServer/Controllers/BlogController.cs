using SparkServer.Core.Repositories;
using SparkServer.Data;
using SparkServer.ViewModels;
using SparkServer.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SparkServer.Application.Enum;

namespace SparkServer.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository<Blog> _blogRepo;
        private readonly IBlogTagRepository<BlogTag> _blogTagRepo;

        public BlogController(IBlogRepository<Blog> blogRepo, IBlogTagRepository<BlogTag> blogTagRepo)
        {
            _blogRepo = blogRepo;
            _blogTagRepo = blogTagRepo;
        }

        public ActionResult Index(int? year, int? month)
        {
            BlogListViewModel viewModel = new BlogListViewModel();
            List<Blog> blogList = new List<Blog>();
            List<BlogTag> tagList = new List<BlogTag>();
            
            if (year.HasValue && month.HasValue)
            {
                // Blogs list by year + month
                blogList = _blogRepo.GetByDate(year.Value, month.Value).OrderByDescending(u => u.PublishDate).ToList();
                string monthName = new DateTime(year.Value, month.Value, 1).ToString("MMMM");
                viewModel.Header = $"Blog Articles for {monthName} {year.ToString()}";
                viewModel.ViewMode = ViewMode.List;
            }
            else if (year.HasValue)
            {
                // Blog list by year only
                blogList = _blogRepo.GetByDate(year.Value, null).OrderByDescending(u => u.PublishDate).ToList();
                viewModel.Header = $"{year.ToString()}";
                viewModel.ViewMode = ViewMode.List;
            }
            else
            {
                // Default: blog overview (top posts)
                blogList = _blogRepo.Get(u => u.Active).OrderByDescending(u => u.PublishDate).ToList();
                viewModel.Header = "Latest Blog Articles";

                if (blogList.Count > 2)
                    viewModel.ViewMode = ViewMode.Overview;
                else
                    viewModel.ViewMode = ViewMode.List;
            }

            tagList = _blogTagRepo.GetAll().OrderBy(u => u.Name).ToList();

            viewModel.MenuSelection = MainMenu.Blog;
            viewModel.MapToViewModel(blogList, tagList);

            // Two possible views are used: IndexList and IndexOverview - use ViewMode value to build view name
            return View(viewName: $"Index{viewModel.ViewMode.ToString()}", model: viewModel);
        }

        public ActionResult BlogArticle(int? year, int? month, string uniqueURL = "")
        {
            BlogArticleViewModel viewModel = new BlogArticleViewModel();

            if (!year.HasValue || !month.HasValue || String.IsNullOrEmpty(uniqueURL))
                return Redirect("/blog");

            var blog = _blogRepo.Get(year.Value, month.Value, uniqueURL);
            var blogTags = _blogTagRepo.GetFromList(blog.BlogsTags.Select(u => u.TagID));

            viewModel.MenuSelection = MainMenu.Blog;
            viewModel.MapToViewModel(blog, blogTags);

            return View(viewModel);
        }

        public ActionResult ListByTag(string tagName)
        {
            BlogListViewModel viewModel = new BlogListViewModel();
            List<Blog> blogList = new List<Blog>();
            List<BlogTag> tagList = new List<BlogTag>();

            var tag = _blogTagRepo.Get(u => u.Name == tagName).FirstOrDefault();
            blogList = _blogRepo.GetByTagID(tag.ID).ToList();
            tagList = _blogTagRepo.GetAll().OrderBy(u => u.Name).ToList();

            viewModel.MapToViewModel(blogList, tagList);
            viewModel.Header = $"Blogs tagged '{tag.Name}'";

            return View(viewName: "IndexList", model: viewModel);
        } 
    }
}