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

namespace SparkServer.Controllers
{
    public class HomeController : Controller
    {
        private IArticleRepository<Article> _articleRepo;

        private string _key = "F9701A3C-080D-49A1-98E6-027FA1D03DDA";

        public HomeController(IArticleRepository<Article> articleRepo)
        {
            _articleRepo = articleRepo;
        }

        public ActionResult Index()
        {
            int ID = 1;

            Article test = _articleRepo.Get(ID);

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Mentoring()
        {
            return View();
        }

        public ActionResult Create(string key)
        {
            if (String.IsNullOrEmpty(key))
                return Redirect("/");

            if (key.ToLower() != _key.ToLower())
                return Redirect("/");

            ArticleAddEditViewModel model = new ArticleAddEditViewModel();
            model.Mode = Application.Enum.EditMode.Add;

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
            model.Mode = Application.Enum.EditMode.Edit;
            
            return View(viewName: "AddEdit", model: model);
        }
    }
}