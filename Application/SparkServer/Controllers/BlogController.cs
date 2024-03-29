﻿using SparkServer.Core.Repositories;
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
            this.ItemsPerPage = 10;
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

            viewModel.Paging.PageCount = (totalItems + this.ItemsPerPage - 1) / this.ItemsPerPage;
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
            viewModel.IsPreview = preview;

            // Should this blog post be displayed at all? (Preview flag overrides denied access in some cases)
            bool shouldDisplay = false;

            // Has published date passed?
            if (viewModel.PublishDate <= DateTime.Now)
            {
                shouldDisplay = true;
            }

            // Is preview mode being used with an authenticated user?
            if (preview && User.Identity.IsAuthenticated)
            {
                shouldDisplay = true;
            }

            if (shouldDisplay)
                return View(viewModel);
            else
                return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public ActionResult ListByTag(string tagName, int? page)
        {
            this.SetupPaging(page);

            BlogListViewModel viewModel = new BlogListViewModel();
            List<Blog> blogList = new List<Blog>();
            List<BlogTag> tagList = new List<BlogTag>();

            var tag = _blogTagRepo.Get(u => u.Name == tagName).FirstOrDefault();
            blogList = _blogRepo.GetByTagID(tag.ID).ToList();
            tagList = _blogTagRepo.GetAll().OrderBy(u => u.Name).ToList();

            viewModel.MapToViewModel(blogList, tagList);
            viewModel.Header = $"Blogs tagged '{tag.Name}'";

            int totalItems = blogList.Count;
            viewModel.BlogList = viewModel.BlogList.OrderByDescending(u => u.PublishDate).Skip(this.SkipCount).Take(this.ItemsPerPage).ToList();

            viewModel.Paging.PageCount = (totalItems + this.ItemsPerPage - 1) / this.ItemsPerPage;
            viewModel.Paging.CurrentPage = this.Page;

            return View(viewName: "IndexOverview", model: viewModel);
        } 
    }
}