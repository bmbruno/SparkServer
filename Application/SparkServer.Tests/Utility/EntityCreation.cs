using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SparkServer;
using SparkServer.Controllers;
using SimpleInjector;
using SparkServer.Data;
using SparkServer.Infrastructure.Repositories;
using SparkServer.Core.Repositories;

namespace SparkServer.Tests.Controllers
{
    // [TestClass]
    public class EntityCreation : TestBase
    {
        public EntityCreation()
        {
            base.InitIOC();
        }

        [TestMethod]
        public void CreateAuthor()
        {
            // Arrange
            IAuthorRepository<Author> authorRepo = this.GetContainer().GetInstance<IAuthorRepository<Author>>();

            // Act
            Author newAuthor = new Author() {
                FirstName = "Brandon",
                LastName = "Bruno",
                Email = "bmbruno@gmail.com",

                Active = true,
                CreateDate = DateTime.Now
            };

            authorRepo.Create(newAuthor);

            // Assert
            Assert.IsNotNull(newAuthor.ID);
        }

        [TestMethod]
        public void CreateCategory()
        {
            ICategoryRepository<Category> catRepo = this.GetContainer().GetInstance<ICategoryRepository<Category>>();

            Category newCategory = new Category();

            newCategory.Name = "Category A";
            newCategory.SortOrder = 1;

            newCategory.Active = true;
            newCategory.CreateDate = DateTime.Now;

            catRepo.Create(newCategory);

            Assert.IsNotNull(newCategory.ID);
        }

        [TestMethod]
        public void CreateSitecoreVersion()
        {
            ISitecoreVersionRepository<SitecoreVersion> svRepo = this.GetContainer().GetInstance<ISitecoreVersionRepository<SitecoreVersion>>();

            SitecoreVersion newSV = new SitecoreVersion();

            newSV.Version = "Sitecore 8.2.1";
            newSV.Revision = "rev 12345";
            newSV.Description = "Sitecore 8.2 Update 1 (rev 12345)";

            newSV.Active = true;
            newSV.CreateDate = DateTime.Now;

            svRepo.Create(newSV);

            Assert.IsNotNull(newSV.ID);
        }

        [TestMethod]
        public void CreateArticle()
        {
            IArticleRepository<Article> articleRepo = this.GetContainer().GetInstance<IArticleRepository<Article>>();

            Article newArticle = new Article()
            {
                AuthorID = 1,
                Title = "Article Number One",
                Body = "<h2>Hello, World!</h2><p>How are we doing on this fine evening?</p>",
                UniqueURL = "article-number-one",
                CategoryID = 1,
                SitecoreVersionID = 1,
                PublishDate = DateTime.Now,

                Active = true,
                CreateDate = DateTime.Now
            };

            articleRepo.Create(newArticle);

            Assert.IsNotNull(newArticle.ID);
        }
    }
}
