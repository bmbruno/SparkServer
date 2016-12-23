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

        public ActionResult Index()
        {
            Blog newBlog = new Blog()
            {
                Title = "Test Title",
                Subtitle = "Subtitle",
                AuthorID = 1,
                Body = "<h1>Hello, World!</h1>",
                PublishDate = DateTime.Now,

                Active = true,
                CreateDate = DateTime.Now
            };

            this._blogRepo.Create(newBlog);

            return View();
        }
    }
}