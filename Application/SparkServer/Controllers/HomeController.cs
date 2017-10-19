using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SparkServer.Core;
using SparkServer.Infrastructure;
using SimpleInjector;
using SparkServer.Core.Repositories;
using SparkServer.ViewModels;
using SparkServer.Data;
using SparkServer.Application.Enum;
using SparkServer.Mapping;

namespace SparkServer.Controllers
{
    public class HomeController : Controller
    {
        private IArticleRepository<Article> _articleRepo;
        private IBlogRepository<Blog> _blogRepo;

        private string _key = "F9701A3C-080D-49A1-98E6-027FA1D03DDA";

        public HomeController(IArticleRepository<Article> articleRepo, IBlogRepository<Blog> blogRepo)
        {
            _articleRepo = articleRepo;
            _blogRepo = blogRepo;
        }

        public ActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel();

            var articles = _articleRepo.GetRecent(4);
            var blogs = _blogRepo.GetRecent(2);
        
            viewModel.MapToViewModel(articles, blogs);
            viewModel.MenuSelection = MainMenu.Home;

            return View(viewModel);
        }

        public ActionResult About()
        {
            HomeViewModel viewModel = new HomeViewModel();
            viewModel.MenuSelection = MainMenu.About;

            return View(viewModel);
        }

        public ActionResult Videos()
        {
            HomeVideoViewModel viewModel = new HomeVideoViewModel();

            // TODO: get videos

            // TODO: map to viewmodel

            return View(viewModel);
        }

        public ActionResult Create(string key)
        {
            if (String.IsNullOrEmpty(key))
                return Redirect("/");

            if (key.ToLower() != _key.ToLower())
                return Redirect("/");

            ArticleAddEditViewModel model = new ArticleAddEditViewModel();
            model.Mode = EditMode.Add;

            return View(viewName: "AddEdit", model: model);
        }

        public ActionResult Edit(string key, int id)
        {
            if (String.IsNullOrEmpty(key))
                return Redirect("/");

            if (key.ToLower() != _key.ToLower())
                return Redirect("/");

            Article article = _articleRepo.Get(id);

            if (article == null)
                Redirect("/");

            ArticleAddEditViewModel model = new ArticleAddEditViewModel();
            model.Mode = EditMode.Edit;
            
            return View(viewName: "AddEdit", model: model);
        }
    }
}