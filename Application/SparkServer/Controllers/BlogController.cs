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
    public class BlogController : BaseController
    {
        private readonly IBlogRepository<Blog> _blogRepo;
        private readonly IBlogTagRepository<BlogTag> _blogTagRepo;

        public BlogController(IBlogRepository<Blog> blogRepo, IBlogTagRepository<BlogTag> blogTagRepo)
        {
            _blogRepo = blogRepo;
            _blogTagRepo = blogTagRepo;
            this.ItemsPerPage = 2;
        }

        public ActionResult Index(int? year, int? month, int? page)
        {
            this.SetupPaging(page);

            BlogListViewModel viewModel = new BlogListViewModel();
            List<Blog> blogList = new List<Blog>();
            List<BlogTag> tagList = new List<BlogTag>();
            
            if (year.HasValue && month.HasValue)
            {
                // Blogs list by year + month
                blogList = _blogRepo.GetByDate(year.Value, month.Value).OrderByDescending(u => u.PublishDate).ToList();
                string monthName = new DateTime(year.Value, month.Value, 1).ToString("MMMM");
                viewModel.Header = $"Blog Posts for {monthName} {year.ToString()}";
            }
            else if (year.HasValue)
            {
                // Blog list by year only
                blogList = _blogRepo.GetByDate(year.Value, null).OrderByDescending(u => u.PublishDate).ToList();
                viewModel.Header = $"Blog Posts for {year.ToString()}";
            }
            else
            {
                // Default: blog overview (top posts)
                blogList = _blogRepo.Get(u => u.Active && u.PublishDate <= DateTime.Now).OrderByDescending(u => u.PublishDate).ToList();
                viewModel.Header = "Latest Blog Posts";
            }

            tagList = _blogTagRepo.GetAll().OrderBy(u => u.Name).ToList();

            int totalItems = blogList.Count;
            blogList = blogList.Skip(this.SkipCount).Take(this.ItemsPerPage).ToList();

            viewModel.MapToViewModel(blogList, tagList);

            viewModel.Paging.PageCount = (totalItems / this.ItemsPerPage);
            viewModel.Paging.CurrentPage = this.Page;

            return View(viewName: $"IndexOverview", model: viewModel);
        }

        public ActionResult BlogArticle(int year, int month, string uniqueURL = "", bool preview = false)
        {
            BlogArticleViewModel viewModel = new BlogArticleViewModel();

            if (String.IsNullOrEmpty(uniqueURL))
                return RedirectToAction(actionName: "Index", controllerName: "Blog");

            var blog = _blogRepo.Get(year, month, uniqueURL);
            var blogTags = _blogTagRepo.GetFromList(blog.BlogsTags.Select(u => u.TagID));

            viewModel.MapToViewModel(blog, blogTags);

            if (preview)
            {
                viewModel.Title = $"[PREVIEW] - {viewModel.Title}";
            }

            // Should this blog post be displayed at all?
            // TODO: redirect to a custom 404
            if (!User.Identity.IsAuthenticated && !preview && viewModel.PublishDate > DateTime.Now)
            {
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }

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

            viewModel.BlogList = viewModel.BlogList.OrderByDescending(u => u.PublishDate).ToList();

            return View(viewName: "IndexList", model: viewModel);
        } 

        public ActionResult Sample()
        {
            BlogArticleViewModel viewModel = new BlogArticleViewModel();
            viewModel.AuthorFullName = "Brandon Bruno";
            viewModel.BlogTags = new List<BlogTagViewModel>() { new BlogTagViewModel() { BlogTagID = 0, BlogTagName = "Community" } };
            viewModel.PublishDate = new DateTime(year: 2017, month: 4, day: 25);
            viewModel.Title = "Fun with Sitecore Powershell Extensions: Learn Something Now";
            viewModel.Subtitle = "This is Great Subtitle For a Blog Post";

            return View(viewModel);
        }
    }
}