using SparkServer.Core.Repositories;
using SparkServer.Data;
using SparkServer.ViewModels;
using SparkServer.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkServer.Controllers
{
    public class CategoryController : Controller
    {
        private IArticleRepository<Article> _articleRepo;
        private ICategoryRepository<Category> _categoryRepo;

        public CategoryController(IArticleRepository<Article> articleRepo, ICategoryRepository<Category> categoryRepo)
        {
            _articleRepo = articleRepo;
            _categoryRepo = categoryRepo;
        }

        public ActionResult Index()
        {
            // Get all active categories
            List<Category> categories = _categoryRepo.Get(x => x.Active).ToList();
            List<Article> articles = _articleRepo.GetAll().ToList();

            // Map to viewmodel
            CategoryListViewModel viewModel = new CategoryListViewModel();
            viewModel.MapToViewModel(categories, articles);

            return View(viewName: "Index", model: viewModel);
        }
    }
}


