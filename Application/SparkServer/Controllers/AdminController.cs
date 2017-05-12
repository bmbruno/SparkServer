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
    public class AdminController : Controller
    {
        private IArticleRepository<Article> _articleRepo;
        private IBlogRepository<Blog> _blogRepo;
        private IBlogTagRepository<BlogTag> _blogTagRepo;
        private ICategoryRepository<Category> _categoryRepo;

        public AdminController(IArticleRepository<Article> articleRepo,
                               IBlogRepository<Blog> blogRepo,
                               IBlogTagRepository<BlogTag> blogTagRepo,
                               ICategoryRepository<Category> categoryRepo)
        {
            _articleRepo = articleRepo;
            _blogRepo = blogRepo;
            _blogTagRepo = blogTagRepo;
            _categoryRepo = categoryRepo;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BlogList()
        {
            return View();
        }

        public ActionResult BlogEdit(int? ID)
        {
            if (ID.HasValue)
            {
                // EDIT
            }
            else
            {
                // ADD
            }

            return View();
        }

        public ActionResult Article(string uniqueURL)
        {
            if (String.IsNullOrEmpty(uniqueURL))
                return Redirect("/");

            try
            {
                var article = _articleRepo.Get(uniqueURL: uniqueURL);

                if (article == null)

                {
                    // TODO: Critical error: log this and notify someone
                    return Redirect("/");
                }

                // Map to viewmodel
                ArticleViewModel viewModel = new ArticleViewModel();
                viewModel.MapToViewModel(article);

                return View(viewName: "Article", model: viewModel);
            }
            catch (Exception exc)
            {
                // TODO: log this exception and display an error message
                return View("/");
            }
        }

        public ActionResult Sample()
        {
            ArticleViewModel viewModel = new ArticleViewModel();
            viewModel.ArticleTitle = "Introduction to Templates in Sitecore";
            viewModel.AuthurFullName = "Brandon Bruno";
            viewModel.CategoryID = 1;
            viewModel.CategoryName = "Introduction to Sitecore";
            viewModel.PublishDateLong = "April 25, 2017";
            viewModel.SitecoreVersionDescription = "Sitecore 8.2.1";

            return View(viewModel);
        }
    }
}


