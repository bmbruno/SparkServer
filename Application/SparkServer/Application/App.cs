﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;
using SparkServer.Infrastructure.Entities;

namespace SparkServer.Application
{
    public static class App
    {
        public static IDependencyResolver RegisterIOC()
        {
            Container container = new Container();

            // Repository registration
            container.Register<Core.Repositories.IArticleRepository<Article>, Infrastructure.Repositories.ArticleRepository>(Lifestyle.Transient);

            // Class registration
            container.Register<Core.Entities.IArticle, Infrastructure.Entities.Article>(Lifestyle.Transient);

            container.Verify();

            return new SimpleInjectorDependencyResolver(container);
        }
    }
}