using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using SparkServer.Core.Repositories;
using SparkServer.Data;
using SparkServer.Infrastructure.Repositories;

namespace SparkServer.Tests
{
    public abstract class TestBase
    {
        private Container _container { get; set; }

        /// <summary>
        /// Returns the current instance of the IOC container.
        /// </summary>
        /// <returns></returns>
        protected Container GetContainer()
        {
            return this._container;
        }

        /// <summary>
        /// Sets up IOC bindings of interfaces to mock implementation classes.
        /// </summary>
        public void InitIOC()
        {
            _container = new Container();

            // Repository registration - mocks for testing
            _container.Register<IArticleRepository<Article>, ArticleRepository>(Lifestyle.Transient);
            _container.Register<ICategoryRepository<Category>, CategoryRepository>(Lifestyle.Transient);
            _container.Register<IBlogRepository<Blog>, BlogRepository>(Lifestyle.Transient);
            _container.Register<IAuthorRepository<Author>, AuthorRepository>(Lifestyle.Transient);
            _container.Register<ISitecoreVersionRepository<SitecoreVersion>, SitecoreVersionRepository>(Lifestyle.Transient);

            _container.Verify();
        }

    }
}
