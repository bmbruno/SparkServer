using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkServer.Controllers
{
    public class BaseController : Controller
    {
        internal int Page { get; set; }

        internal int ItemsPerPage { get; set; }

        internal int SkipCount { get { return (this.Page - 1) * this.ItemsPerPage; } }

        internal void SetupPaging(int? page)
        {
            if (page.HasValue)
                this.Page = page.Value;
            else
                this.Page = 1;
        }
    }
}