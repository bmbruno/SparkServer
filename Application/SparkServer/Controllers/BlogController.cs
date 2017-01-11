using SparkServer.Core.Repositories;
using SparkServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkServer.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository<Blog> _blogRepo;

        public BlogController(IBlogRepository<Blog> blogRepo)
        {
            _blogRepo = blogRepo;
        }

        public ActionResult Index(int year, int month, int day, string uniqueURL)
        {
            if (String.IsNullOrEmpty(uniqueURL))
                return Redirect("/");

            //var article = _blogRepo.Get(uniqueURL: uniqueURL);

            //if (article == null)
            //{
            //    // TODO: Critical error: log this and notify someone
            //    return Redirect("/");
            //}

            //// Map to viewmodel
            //ArticleViewModel viewModel = new ArticleViewModel();
            //viewModel.MapToViewModel(article);

            //return View(viewName: "Index", model: viewModel);

            return View();
        }
    }
}