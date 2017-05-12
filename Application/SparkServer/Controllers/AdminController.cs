using SparkServer.Core.Repositories;
using SparkServer.Data;
using SparkServer.ViewModels;
using SparkServer.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SparkServer.Application.Enum;
using SparkServer.Application;

namespace SparkServer.Controllers
{
    public class AdminController : Controller
    {
        private IArticleRepository<Article> _articleRepo;
        private IBlogRepository<Blog> _blogRepo;
        private IBlogTagRepository<BlogTag> _blogTagRepo;
        private ICategoryRepository<Category> _categoryRepo;
        private IAuthorRepository<Author> _authorRepo;

        public AdminController(IArticleRepository<Article> articleRepo,
                               IBlogRepository<Blog> blogRepo,
                               IBlogTagRepository<BlogTag> blogTagRepo,
                               ICategoryRepository<Category> categoryRepo,
                               IAuthorRepository<Author> authorRepo)
        {
            _articleRepo = articleRepo;
            _blogRepo = blogRepo;
            _blogTagRepo = blogTagRepo;
            _categoryRepo = categoryRepo;
            _authorRepo = authorRepo;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BlogList()
        {
            return View();
        }

        public ActionResult BlogEdit(int? ID)
        {
            BlogEditViewModel viewModel = new BlogEditViewModel();

            if (ID.HasValue)
            {
                // EDIT

                viewModel.Mode = EditMode.Edit;

                var blog = _blogRepo.Get(ID: ID.Value);

                if (blog == null)
                {
                    TempData["Error"] = $"No blog found with ID {ID.Value}.";
                    return RedirectToAction(actionName: "Index", controllerName: "Admin");
                }

                viewModel.ID = blog.ID;
                viewModel.Title = blog.Title;
                viewModel.Subtitle = blog.Subtitle;
                viewModel.Body = blog.Body;
                viewModel.PublishDate = blog.PublishDate;
                viewModel.AuthorID = blog.AuthorID;
                viewModel.UniqueURL = blog.UniqueURL;
                viewModel.ImagePath = blog.ImagePath;
                viewModel.ImageThumbnailPath = blog.ImageThumbnailPath;

                viewModel.AuthorList = FilterData.Authors(_authorRepo, viewModel.AuthorID);
            }
            else
            {
                // ADD

                viewModel.Mode = EditMode.Add;

                viewModel.AuthorList = FilterData.Authors(_authorRepo, null);
            }

            return View(model: viewModel);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult BlogUpdate(BlogEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.Mode == EditMode.Add)
                {
                    // TODO - write ADD code
                }
                else
                {
                    var blog = _blogRepo.Get(viewModel.ID);

                    if (blog == null)
                    {
                        TempData["Error"] = $"No blog found with ID {viewModel.ID}.";
                        return RedirectToAction(actionName: "Index", controllerName: "Admin");
                    }

                    blog.Title = viewModel.Title;
                    blog.Subtitle = viewModel.Subtitle;
                    blog.Body = viewModel.Body;
                    blog.PublishDate = viewModel.PublishDate;
                    blog.AuthorID = viewModel.AuthorID;
                    blog.UniqueURL = viewModel.UniqueURL;
                    blog.ImagePath = viewModel.ImagePath;
                    blog.ImageThumbnailPath = viewModel.ImageThumbnailPath;

                    _blogRepo.Update(blog);

                    TempData["Success"] = "Blog updated.";
                    return RedirectToAction(actionName: "BlogList", controllerName: "Admin");
                }

            }
            else
            {
                TempData["Error"] = "Please correct the errors below.";
            }

            return RedirectToAction("BlogEdit", viewModel);
        }

        public ActionResult Article(string uniqueURL)
        {
            if (String.IsNullOrEmpty(uniqueURL))
                return Redirect("/");

            try
            {
                var article = _articleRepo.Get(uniqueURL: uniqueURL);

                if (article == null)

                {
                    // TODO: Critical error: log this and notify someone
                    return Redirect("/");
                }

                // Map to viewmodel
                ArticleViewModel viewModel = new ArticleViewModel();
                viewModel.MapToViewModel(article);

                return View(viewName: "Article", model: viewModel);
            }
            catch (Exception exc)
            {
                // TODO: log this exception and display an error message
                return View("/");
            }
        }

        public ActionResult Sample()
        {
            ArticleViewModel viewModel = new ArticleViewModel();
            viewModel.ArticleTitle = "Introduction to Templates in Sitecore";
            viewModel.AuthurFullName = "Brandon Bruno";
            viewModel.CategoryID = 1;
            viewModel.CategoryName = "Introduction to Sitecore";
            viewModel.PublishDateLong = "April 25, 2017";
            viewModel.SitecoreVersionDescription = "Sitecore 8.2.1";

            return View(viewModel);
        }
    }
}


