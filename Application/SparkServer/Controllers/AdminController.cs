﻿using SparkServer.Core.Repositories;
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
using System.Web.Security;

namespace SparkServer.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IArticleRepository<Article> _articleRepo;
        private IBlogRepository<Blog> _blogRepo;
        private IBlogTagRepository<BlogTag> _blogTagRepo;
        private ICategoryRepository<Category> _categoryRepo;
        private IAuthorRepository<Author> _authorRepo;
        private ISitecoreVersionRepository<SitecoreVersion> _sitecoreVersionRepo;
        private IVideoRepository<Video> _videoRepo;

        public AdminController(IArticleRepository<Article> articleRepo,
                               IBlogRepository<Blog> blogRepo,
                               IBlogTagRepository<BlogTag> blogTagRepo,
                               ICategoryRepository<Category> categoryRepo,
                               IAuthorRepository<Author> authorRepo,
                               ISitecoreVersionRepository<SitecoreVersion> sitecoreVersionRepo,
                               IVideoRepository<Video> videoRepo)
        {
            _articleRepo = articleRepo;
            _blogRepo = blogRepo;
            _blogTagRepo = blogTagRepo;
            _categoryRepo = categoryRepo;
            _authorRepo = authorRepo;
            _sitecoreVersionRepo = sitecoreVersionRepo;
            _videoRepo = videoRepo;
        }

        [AllowAnonymous]
        public ActionResult Login(string token)
        {
            if (token == Config.AdminToken)
            {
                FormsAuthentication.SetAuthCookie("1", true);
                return RedirectToAction(actionName: "Index", controllerName: "Admin");
            }

            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        public ActionResult Index()
        { 
            return View();
        }

        #region Article

        public ActionResult ArticleList()
        {
            ArticleEditListViewModel viewModel = new ArticleEditListViewModel();

            var articles = _articleRepo.GetAll().OrderByDescending(u => u.Category.SortOrder).ThenBy(u => u.SortOrder);

            foreach (var article in articles)
            {
                viewModel.ArticleList.Add(new ArticleListItemViewModel()
                {
                    ID = article.ID,
                    Title = article.Title,
                    Subtitle = article.Subtitle,
                    CategoryName = $"{article.Category.SortOrder} - {article.Category.Name}",
                    CategorySortOrder = (article.Category.SortOrder.HasValue) ? article.Category.SortOrder.Value : 0,
                    SitecoreVersion = article.SitecoreVersion.Version,
                    PublishedDate = (article.PublishDate.HasValue) ? article.PublishDate.Value.ToShortDateString() : "None",
                    AuthorName = $"{article.Author.FirstName} {article.Author.LastName}",
                    SortOrder = article.SortOrder
                });
            }

            return View(viewModel);
        }

        public ActionResult ArticleEdit(int? ID)
        {
            ArticleEditViewModel viewModel = new ArticleEditViewModel();

            if (ID.HasValue)
            {
                // EDIT

                viewModel.Mode = EditMode.Edit;

                var article = _articleRepo.Get(ID: ID.Value);

                if (article == null)
                {
                    TempData["Error"] = $"No Article found with ID {ID.Value}.";
                    return RedirectToAction(actionName: "Index", controllerName: "Admin");
                }

                viewModel.ID = article.ID;
                viewModel.Title = article.Title;
                viewModel.Subtitle = article.Subtitle;
                viewModel.CategoryID = article.CategoryID;
                viewModel.SitecoreVersionID = article.SitecoreVersionID;
                viewModel.Body = article.Body;
                viewModel.PublishDate = article.PublishDate;
                viewModel.AuthorID = article.AuthorID;
                viewModel.UniqueURL = article.UniqueURL;
                viewModel.SortOrder = article.SortOrder;

                // TODO: marked for possible removal if RelatedArticles concept doesn't stick
                // viewModel.RelatedArticles = article.RelatedArticle.Select(u => u.ArticleID).ToList();

                foreach (var relatedLink in article.RelatedArticleLinks.OrderBy(u => u.SortOrder))
                {
                    viewModel.RelatedLinks.Add(new RelatedLinkItemViewModel()
                    {
                        ID = relatedLink.ID,
                        Title = relatedLink.Title,
                        HREF = relatedLink.HREF,
                        Deleted = false
                    });
                }

                viewModel.AuthorSource = FilterData.Authors(_authorRepo, viewModel.AuthorID);
                viewModel.CategorySource = FilterData.Categories(_categoryRepo, viewModel.CategoryID);
                viewModel.SitecoreVersionSource = FilterData.SitecoreVersions(_sitecoreVersionRepo, viewModel.SitecoreVersionID);

                // TODO: marked for removal
                // viewModel.RelatedArticlesSource = FilterData.Articles(_articleRepo, viewModel.RelatedArticles);
            }
            else
            {
                // ADD

                viewModel.Mode = EditMode.Add;

                viewModel.AuthorSource = FilterData.Authors(_authorRepo, null);
                viewModel.CategorySource = FilterData.Categories(_categoryRepo, null);
                viewModel.SitecoreVersionSource = FilterData.SitecoreVersions(_sitecoreVersionRepo, null);
            }

            return View(model: viewModel);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ArticleUpdate(ArticleEditViewModel viewModel)
        {
            // Check for unique URL
            if (viewModel.Mode == EditMode.Add)
            {
                var existingArticle = _articleRepo.Get(u => u.UniqueURL == viewModel.UniqueURL).FirstOrDefault();

                if (existingArticle != null)
                    ModelState.AddModelError("UniqueURL", "URL is not unique!");
            }

            if (ModelState.IsValid)
            {
                if (viewModel.Mode == EditMode.Add)
                {
                    Article article = new Article();

                    article.Title = viewModel.Title;
                    article.Subtitle = viewModel.Subtitle;
                    article.CategoryID = viewModel.CategoryID;
                    article.SitecoreVersionID = viewModel.SitecoreVersionID;
                    article.Body = viewModel.Body;
                    article.PublishDate = viewModel.PublishDate;
                    article.AuthorID = viewModel.AuthorID;
                    article.UniqueURL = viewModel.UniqueURL;
                    article.SortOrder = viewModel.SortOrder;

                    article.Active = true;
                    article.CreateDate = DateTime.Now;

                    // Process deletions - check if any are marked deleted
                    foreach (var related in viewModel.RelatedLinks)
                    {
                        if (related.Deleted)
                        {
                            try
                            {
                                _articleRepo.DeleteRelatedLink(related.ID);
                            }
                            catch (Exception exc)
                            {
                                TempData["Error"] = $"Error deleting related link for ID {related.ID}. Exception: {exc.Message}";
                            }
                        }
                    }

                    // TODO: Process updates to existing items

                    // TODO: Process new items
                    

                    _articleRepo.Create(article);

                    TempData["Success"] = "Article created.";
                    return RedirectToAction(actionName: "ArticleList", controllerName: "Admin");
                }
                else
                {
                    var article = _articleRepo.Get(viewModel.ID);

                    if (article == null)
                    {
                        TempData["Error"] = $"No Article found with ID {viewModel.ID}.";
                        return RedirectToAction(actionName: "Index", controllerName: "Admin");
                    }

                    article.Title = viewModel.Title;
                    article.Subtitle = viewModel.Subtitle;
                    article.CategoryID = viewModel.CategoryID;
                    article.SitecoreVersionID = viewModel.SitecoreVersionID;
                    article.Body = viewModel.Body;
                    article.PublishDate = viewModel.PublishDate;
                    article.AuthorID = viewModel.AuthorID;
                    article.UniqueURL = viewModel.UniqueURL;
                    article.SortOrder = viewModel.SortOrder;

                    _articleRepo.Update(article);

                    TempData["Success"] = "Article updated.";
                    return RedirectToAction(actionName: "ArticleList", controllerName: "Admin");
                }

            }
            else
            {
                TempData["Error"] = "Please correct the errors below.";
            }

            viewModel.AuthorSource = FilterData.Authors(_authorRepo, viewModel.AuthorID);
            viewModel.CategorySource = FilterData.Categories(_categoryRepo, viewModel.CategoryID);
            viewModel.SitecoreVersionSource = FilterData.SitecoreVersions(_sitecoreVersionRepo, viewModel.SitecoreVersionID);

            return View("ArticleEdit", viewModel);
        }

        public ActionResult ArticleDelete(int? ID)
        {
            if (ID.HasValue)
            {
                _blogRepo.Delete(ID.Value);

                TempData["Success"] = "Blog deleted.";
            }
            else
            {
                TempData["Error"] = "ID required to delete blog.";
            }

            return RedirectToAction(actionName: "BlogList", controllerName: "Admin");
        }

        #endregion

        #region Blog

        public ActionResult BlogList()
        {
            BlogEditListViewModel viewModel = new BlogEditListViewModel();

            var blogs = _blogRepo.GetAll().OrderByDescending(u => u.CreateDate);

            foreach (var blog in blogs)
            {
                viewModel.BlogList.Add(new BlogListItemViewModel() {
                    ID = blog.ID,
                    Title = blog.Title,
                    Subtitle = blog.Subtitle,
                    PublishedDate = (blog.PublishDate.HasValue) ? blog.PublishDate.Value.ToShortDateString() : "None",
                    AuthorName = $"{blog.Author.FirstName} {blog.Author.LastName}"
                });
            }

            return View(viewModel);
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
                viewModel.BlogURL = $"/blog/{blog.PublishDate.Value.Year}/{blog.PublishDate.Value.Month}/{blog.UniqueURL}";

                viewModel.BlogTags = blog.BlogsTags.Select(u => u.TagID).ToList();

                viewModel.AuthorSource = FilterData.Authors(_authorRepo, viewModel.AuthorID);
                viewModel.BlogTagSource = FilterData.BlogTags(_blogTagRepo, viewModel.BlogTags);
            }
            else
            {
                // ADD

                viewModel.Mode = EditMode.Add;

                viewModel.ID = 0;
                viewModel.AuthorSource = FilterData.Authors(_authorRepo, null);
                viewModel.BlogTagSource = FilterData.BlogTags(_blogTagRepo, viewModel.BlogTags);
            }

            return View(model: viewModel);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult BlogUpdate(BlogEditViewModel viewModel)
        {
            // Check for unique URL
            if (viewModel.Mode == EditMode.Add)
            {
                var existingBlog = _blogRepo.Get(u => u.UniqueURL == viewModel.UniqueURL).FirstOrDefault();

                if (existingBlog != null)
                    ModelState.AddModelError("UniqueURL", "URL is not unique!");
            }

            if (ModelState.IsValid)
            {
                if (viewModel.Mode == EditMode.Add)
                {
                    Blog blog = new Blog();

                    blog.Title = viewModel.Title;
                    blog.Subtitle = viewModel.Subtitle;
                    blog.Body = viewModel.Body;
                    blog.PublishDate = viewModel.PublishDate;
                    blog.AuthorID = viewModel.AuthorID;
                    blog.UniqueURL = viewModel.UniqueURL;
                    blog.ImagePath = viewModel.ImagePath;
                    blog.ImageThumbnailPath = viewModel.ImageThumbnailPath;

                    blog.Active = true;
                    blog.CreateDate = DateTime.Now;

                    _blogRepo.Create(blog);
                    _blogTagRepo.UpdateTagsForBlog(blog.ID, viewModel.BlogTags);
                    
                    TempData["Success"] = "Blog created.";
                    return RedirectToAction(actionName: "BlogEdit", controllerName: "Admin", routeValues: new { ID = blog.ID });
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
                    _blogTagRepo.UpdateTagsForBlog(blog.ID, viewModel.BlogTags);

                    TempData["Success"] = "Blog updated.";
                    return RedirectToAction(actionName: "BlogEdit", controllerName: "Admin", routeValues: new { ID = blog.ID });
                }

            }
            else
            {
                TempData["Error"] = "Please correct the errors below.";
            }

            viewModel.AuthorSource = FilterData.Authors(_authorRepo, viewModel.AuthorID);
            viewModel.BlogTagSource = FilterData.BlogTags(_blogTagRepo, viewModel.BlogTags);

            return View("BlogEdit", viewModel);
        }

        public ActionResult BlogDelete(int? ID)
        {
            if (ID.HasValue)
            {
                _blogRepo.Delete(ID.Value);

                TempData["Success"] = "Blog deleted.";
            }
            else
            {
                TempData["Error"] = "ID required to delete blog.";
            }

            return RedirectToAction(actionName: "BlogList", controllerName: "Admin");
        }

        #endregion

        #region BlogTags

        public ActionResult BlogTagList()
        {
            BlogTagEditListViewModel viewModel = new BlogTagEditListViewModel();

            var allTags = _blogTagRepo.GetAll().OrderBy(u => u.Name);

            foreach (var tag in allTags)
            {
                viewModel.BlogTagList.Add(new BlogTagListItemViewModel()
                {
                    ID = tag.ID,
                    Name = tag.Name
                });
            }

            return View(viewModel);
        }

        public ActionResult BlogTagEdit(int? ID)
        {
            BlogTagEditViewModel viewModel = new BlogTagEditViewModel();

            if (ID.HasValue)
            {
                // EDIT

                viewModel.Mode = EditMode.Edit;

                var blog = _blogTagRepo.Get(ID: ID.Value);

                if (blog == null)
                {
                    TempData["Error"] = $"No Blog Tag found with ID {ID.Value}.";
                    return RedirectToAction(actionName: "Index", controllerName: "Admin");
                }

                viewModel.ID = blog.ID;
                viewModel.Name = blog.Name;
            }
            else
            {
                // ADD

                viewModel.Mode = EditMode.Add;
            }

            return View(model: viewModel);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult BlogTagUpdate(BlogTagEditViewModel viewModel)
        {
            // Check for existing Name
            if (viewModel.Mode == EditMode.Add)
            {
                var existingBlog = _blogTagRepo.Get(u => u.Name == viewModel.Name).FirstOrDefault();

                if (existingBlog != null)
                    ModelState.AddModelError("Name", "Name is not unique!");
            }

            if (ModelState.IsValid)
            {
                if (viewModel.Mode == EditMode.Add)
                {
                    BlogTag blogTag = new BlogTag();

                    blogTag.Name = viewModel.Name;

                    blogTag.Active = true;
                    blogTag.CreateDate = DateTime.Now;

                    _blogTagRepo.Create(blogTag);

                    TempData["Success"] = "Blog Tag created.";
                    return RedirectToAction(actionName: "BlogTagList", controllerName: "Admin");
                }
                else
                {
                    var blogTag = _blogTagRepo.Get(viewModel.ID);

                    if (blogTag == null)
                    {
                        TempData["Error"] = $"No Blog Tag found with ID {viewModel.ID}.";
                        return RedirectToAction(actionName: "Index", controllerName: "Admin");
                    }

                    blogTag.Name = viewModel.Name;

                    _blogTagRepo.Update(blogTag);

                    TempData["Success"] = "Blog Tag updated.";
                    return RedirectToAction(actionName: "BlogTagList", controllerName: "Admin");
                }

            }
            else
            {
                TempData["Error"] = "Please correct the errors below.";
            }

            return View("BlogTagEdit", viewModel);
        }

        public ActionResult BlogTagDelete(int? ID)
        {
            if (ID.HasValue)
            {
                _blogTagRepo.Delete(ID.Value);

                TempData["Success"] = "Blog tag deleted.";
            }
            else
            {
                TempData["Error"] = "ID required to delete blog tag.";
            }

            return RedirectToAction(actionName: "BlogTagList", controllerName: "Admin");
        }

        #endregion

        #region Categories

        public ActionResult CategoryList()
        {
            CategoryEditListViewModel viewModel = new CategoryEditListViewModel();

            var allTags = _categoryRepo.GetAll().OrderBy(u => u.SortOrder);

            foreach (var cat in allTags)
            {
                viewModel.CategoryList.Add(new CategoryListItemViewModel()
                {
                    ID = cat.ID,
                    Name = cat.Name,
                    SortOrder = cat.SortOrder.Value
                });
            }

            return View(viewModel);
        }

        public ActionResult CategoryEdit(int? ID)
        {
            CategoryEditViewModel viewModel = new CategoryEditViewModel();

            if (ID.HasValue)
            {
                // EDIT

                viewModel.Mode = EditMode.Edit;
                
                var category = _categoryRepo.Get(ID: ID.Value);

                if (category == null)
                {
                    TempData["Error"] = $"No Category found with ID {ID.Value}.";
                    return RedirectToAction(actionName: "Index", controllerName: "Admin");
                }

                viewModel.ID = category.ID;
                viewModel.Name = category.Name;
                viewModel.SortOrder = category.SortOrder.Value;
            }
            else
            {
                // ADD

                viewModel.Mode = EditMode.Add;
            }

            return View(model: viewModel);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CategoryUpdate(CategoryEditViewModel viewModel)
        {
            // Check for existing Name
            if (viewModel.Mode == EditMode.Add)
            {
                var existingCategory = _categoryRepo.Get(u => u.Name == viewModel.Name).FirstOrDefault();

                if (existingCategory != null)
                    ModelState.AddModelError("Name", "Name is not unique!");
            }

            if (ModelState.IsValid)
            {
                if (viewModel.Mode == EditMode.Add)
                {
                    Category category = new Category();

                    category.Name = viewModel.Name;
                    category.SortOrder = viewModel.SortOrder;

                    category.Active = true;
                    category.CreateDate = DateTime.Now;
                    _categoryRepo.Create(category);

                    TempData["Success"] = "Category created.";
                    return RedirectToAction(actionName: "CategoryList", controllerName: "Admin");
                }
                else
                {
                    var category = _categoryRepo.Get(viewModel.ID);

                    if (category == null)
                    {
                        TempData["Error"] = $"No Category found with ID {viewModel.ID}.";
                        return RedirectToAction(actionName: "Index", controllerName: "Admin");
                    }

                    category.Name = viewModel.Name;
                    category.SortOrder = viewModel.SortOrder;

                    _categoryRepo.Update(category);

                    TempData["Success"] = "Category updated.";
                    return RedirectToAction(actionName: "CategoryList", controllerName: "Admin");
                }

            }
            else
            {
                TempData["Error"] = "Please correct the errors below.";
            }

            return View("CategoryEdit", viewModel);
        }

        public ActionResult CategoryDelete(int? ID)
        {
            if (ID.HasValue)
            {
                _categoryRepo.Delete(ID.Value);

                TempData["Success"] = "Blog tag deleted.";
            }
            else
            {
                TempData["Error"] = "ID required to delete blog tag.";
            }

            return RedirectToAction(actionName: "CategoryList", controllerName: "Admin");
        }

        #endregion

        #region Video

        public ActionResult VideoList()
        {
            VideoEditListViewModel viewModel = new VideoEditListViewModel();

            var Videos = _videoRepo.GetAll().OrderByDescending(u => u.CreateDate);

            foreach (var video in Videos)
            {
                viewModel.VideoList.Add(new VideoListItemViewModel()
                {
                    ID = video.ID,
                    Title = video.Title,
                    Subtitle = video.Subtitle,
                    VideoURL = video.VideoURL,
                    ImageThumbnailPath = video.ImageThumbnailPath,
                    PublishedDate = (video.PublishDate.HasValue) ? video.PublishDate.Value.ToShortDateString() : "None",
                    AuthorName = $"{video.Author.FirstName} {video.Author.LastName}"
                });
            }

            return View(viewModel);
        }

        public ActionResult VideoEdit(int? ID)
        {
            VideoEditViewModel viewModel = new VideoEditViewModel();

            if (ID.HasValue)
            {
                // EDIT

                viewModel.Mode = EditMode.Edit;

                var video = _videoRepo.Get(ID: ID.Value);

                if (video == null)
                {
                    TempData["Error"] = $"No Video found with ID {ID.Value}.";
                    return RedirectToAction(actionName: "Index", controllerName: "Admin");
                }

                viewModel.ID = video.ID;
                viewModel.Title = video.Title;
                viewModel.Subtitle = video.Subtitle;
                viewModel.VideoURL = video.VideoURL;
                viewModel.PublishDate = video.PublishDate;
                viewModel.AuthorID = video.AuthorID;
                viewModel.ImageThumbnailPath = video.ImageThumbnailPath;

                viewModel.AuthorSource = FilterData.Authors(_authorRepo, viewModel.AuthorID);
            }
            else
            {
                // ADD

                viewModel.Mode = EditMode.Add;

                viewModel.AuthorSource = FilterData.Authors(_authorRepo, null);
            }

            return View(model: viewModel);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult VideoUpdate(VideoEditViewModel viewModel)
        {
            // Check for unique URL
            if (viewModel.Mode == EditMode.Add)
            {
                var existingVideo = _videoRepo.Get(u => u.ID == viewModel.ID).FirstOrDefault();

                if (existingVideo != null)
                    ModelState.AddModelError("UniqueURL", "URL is not unique!");
            }

            if (ModelState.IsValid)
            {
                if (viewModel.Mode == EditMode.Add)
                {
                    Video Video = new Video();

                    Video.Title = viewModel.Title;
                    Video.Subtitle = viewModel.Subtitle;
                    Video.VideoURL = viewModel.VideoURL;
                    Video.PublishDate = viewModel.PublishDate;
                    Video.AuthorID = viewModel.AuthorID;
                    Video.ImageThumbnailPath = viewModel.ImageThumbnailPath;

                    Video.Active = true;
                    Video.CreateDate = DateTime.Now;

                    _videoRepo.Create(Video);

                    TempData["Success"] = "Video created.";
                    return RedirectToAction(actionName: "VideoList", controllerName: "Admin");
                }
                else
                {
                    var Video = _videoRepo.Get(viewModel.ID);

                    if (Video == null)
                    {
                        TempData["Error"] = $"No Video found with ID {viewModel.ID}.";
                        return RedirectToAction(actionName: "Index", controllerName: "Admin");
                    }

                    Video.Title = viewModel.Title;
                    Video.Subtitle = viewModel.Subtitle;
                    Video.VideoURL = viewModel.VideoURL;
                    Video.PublishDate = viewModel.PublishDate;
                    Video.AuthorID = viewModel.AuthorID;
                    Video.ImageThumbnailPath = viewModel.ImageThumbnailPath;

                    _videoRepo.Update(Video);

                    TempData["Success"] = "Video updated.";
                    return RedirectToAction(actionName: "VideoList", controllerName: "Admin");
                }

            }
            else
            {
                TempData["Error"] = "Please correct the errors below.";
            }

            viewModel.AuthorSource = FilterData.Authors(_authorRepo, viewModel.AuthorID);

            return View("VideoEdit", viewModel);
        }

        public ActionResult VideoDelete(int? ID)
        {
            if (ID.HasValue)
            {
                _videoRepo.Delete(ID.Value);

                TempData["Success"] = "Video deleted.";
            }
            else
            {
                TempData["Error"] = "ID required to delete Video.";
            }

            return RedirectToAction(actionName: "VideoList", controllerName: "Admin");
        }

        #endregion
    }
}