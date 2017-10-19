using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;
using SparkServer.Data;

namespace SparkServer.Application
{
    public static class AppInit
    {
        public static IDependencyResolver RegisterIOC()
        {
            Container container = new Container();

            // Repository registration
            container.Register<Core.Repositories.IArticleRepository<Article>, Infrastructure.Repositories.ArticleRepository>(Lifestyle.Transient);
            container.Register<Core.Repositories.IBlogRepository<Blog>, Infrastructure.Repositories.BlogRepository>(Lifestyle.Transient);
            container.Register<Core.Repositories.IBlogTagRepository<BlogTag>, Infrastructure.Repositories.BlogTagRepository>(Lifestyle.Transient);
            container.Register<Core.Repositories.ICategoryRepository<Category>, Infrastructure.Repositories.CategoryRepository>(Lifestyle.Transient);
            container.Register<Core.Repositories.IAuthorRepository<Author>, Infrastructure.Repositories.AuthorRepository>(Lifestyle.Transient);
            container.Register<Core.Repositories.ISitecoreVersionRepository<SitecoreVersion>, Infrastructure.Repositories.SitecoreVersionRepository>(Lifestyle.Transient);
            container.Register<Core.Repositories.IVideoRepository<Video>, Infrastructure.Repositories.VideoRepository>(Lifestyle.Transient);

            container.Verify();

            return new SimpleInjectorDependencyResolver(container);
        }
    }
}