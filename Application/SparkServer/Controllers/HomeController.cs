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
        private IVideoRepository<Video> _videoRepo;

        public HomeController(IArticleRepository<Article> articleRepo, IBlogRepository<Blog> blogRepo)
        {
            _articleRepo = articleRepo;
            _blogRepo = blogRepo;
        }

        public ActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel();

            var articles = _articleRepo.GetRecent(0);
            var blogs = _blogRepo.GetRecent(5);
        
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

        public ActionResult Resources()
        {
            ResourcesViewModel viewModel = new ResourcesViewModel();
            viewModel.MenuSelection = MainMenu.Resources;

            return View(viewModel);
        }
    }
}