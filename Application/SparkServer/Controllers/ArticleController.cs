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

            var articles = _articleRepo.Get(uniqueURL);

            if (articles == null)
            {
                // TODO: Critical error: log this and notify someone
                return Redirect("/");
            }

            return Content("OK");
        }
    }
}


