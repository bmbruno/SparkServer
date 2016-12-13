using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkServer.Controllers
{
    public class ArticleController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}