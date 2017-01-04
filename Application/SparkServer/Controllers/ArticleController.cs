using SparkServer.Core.Repositories;
using SparkServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkServer.Controllers
{
    public class ArticleController : Controller
    {
        private IArticleRepository<Article> _articleRepo;

        public ArticleController(IArticleRepository<Article> articleRepo)
        {
            _articleRepo = articleRepo;
        }

        public ActionResult Index(string uniqueURL)
        {
            if (String.IsNullOrEmpty(uniqueURL))
                return Redirect("/");

            var articles = _articleRepo.Get(x => x.UniqueURL == uniqueURL.Trim());

            if (articles == null || articles.Count() > 1)
            {
                // TODO: Critical error: log this and notify someone
                return Redirect("/");
            }

            var article = articles.FirstOrDefault();

            return Content("OK");
        }
    }
}


