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

        public ActionResult Index(int? year, int? month)
        {
            List<Blog> blogList = new List<Blog>();

            if (year.HasValue && month.HasValue)
                blogList = _blogRepo.GetByDate(year.Value, month.Value).ToList();

            if (year.HasValue)
                blogList = _blogRepo.GetByDate(year.Value, null).ToList();

            if (blogList.Count == 0)
                blogList = _blogRepo.Get(u => u.Active).OrderByDescending(u => u.PublishDate).ToList();
                
            return View();
        }

        public ActionResult BlogArticle(int? year, int? month, string uniqueURL = "")
        {
            if (!year.HasValue || !month.HasValue || String.IsNullOrEmpty(uniqueURL))
                return Redirect("/blog");

            var blog = _blogRepo.Get(year.Value, month.Value, uniqueURL);

            return View();
        }

        public ActionResult BlogArticlesByDate(int year, int? month)
        {
            var blog = _blogRepo.GetByDate(year, month.Value);

            if (blog == null)
            {
                // TODO: Critical error: log this and notify someone
                return Redirect("/blog");
            }

            //// Map to viewmodel
            //ArticleViewModel viewModel = new ArticleViewModel();
            //viewModel.MapToViewModel(article);

            //return View(viewName: "Index", model: viewModel);

            return View();
        }
    }
}