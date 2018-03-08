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
    public class HomeControllerTest : TestBase
    {
        /// <summary>
        /// Inits IOC and instantiates the controller under testing.
        /// </summary>
        /// <returns></returns>
        private HomeController SetupController()
        {
            this.InitIOC();
            return new HomeController(
                this.GetContainer().GetInstance<IArticleRepository<Article>>(),
                this.GetContainer().GetInstance<IBlogRepository<Blog>>()
            );
        }

        [TestMethod]
        public void HomeController_Index_ReturnsView()
        {
            // Arrange
            HomeController controller = this.SetupController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
