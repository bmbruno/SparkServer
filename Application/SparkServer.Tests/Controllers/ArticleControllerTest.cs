using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SparkServer;
using SparkServer.Controllers;
using SparkServer.Core.Repositories;
using SparkServer.Data;
using SparkServer.ViewModels;
using SparkServer.Application.Enum;

namespace SparkServer.Tests.Controllers
{
    [TestClass]
    public class ArticleControllerTest : TestBase
    {
        private string _uniqueURL = "article-number-one";

        /// <summary>
        /// Inits IOC and instantiates the controller under testing.
        /// </summary>
        /// <returns></returns>
        private ArticleController SetupController()
        {
            this.InitIOC();
            return new ArticleController(this.GetContainer().GetInstance<IArticleRepository<Article>>());
        }

        [TestMethod]
        public void ArticleController_Index_ReturnsViewWithArticle()
        {
            // Arrange
            ArticleController controller = this.SetupController();

            // Act
            ViewResult result = controller.Index(_uniqueURL) as ViewResult;
            ArticleViewModel viewModel = result.Model as ArticleViewModel;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(viewModel.ArticleID > 0);
        }

    }
}
