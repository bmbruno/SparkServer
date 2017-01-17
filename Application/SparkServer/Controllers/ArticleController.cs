﻿using SparkServer.Core.Repositories;
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
    public class ArticleController : Controller
    {
        private IArticleRepository<Article> _articleRepo;

        public ArticleController(IArticleRepository<Article> articleRepo)
        {
            _articleRepo = articleRepo;
        }

        public ActionResult Article(string uniqueURL)
        {
            if (String.IsNullOrEmpty(uniqueURL))
                return Redirect("/");

            var article = _articleRepo.Get(uniqueURL: uniqueURL);

            if (article == null)
            {
                // TODO: Critical error: log this and notify someone
                return Redirect("/");
            }

            // Map to viewmodel
            ArticleViewModel viewModel = new ArticleViewModel();
            viewModel.MapToViewModel(article);

            return View(viewName: "Index", model: viewModel);
        }
    }
}


