using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SparkServer.Core;
using SparkServer.Infrastructure;
using SimpleInjector;
using SparkServer.Core.Repositories;
using SparkServer.Core.Entities;
using SparkServer.Infrastructure.Entities;

namespace SparkServer.Controllers
{
    public class HomeController : Controller
    {
        private IArticleRepository<Article> _articleRepo;

        public HomeController(IArticleRepository<Article> articleRepo)
        {
            _articleRepo = articleRepo;
        }

        public ActionResult Index()
        {
            Article test = _articleRepo.Get();

            return View();
        }
    }
}