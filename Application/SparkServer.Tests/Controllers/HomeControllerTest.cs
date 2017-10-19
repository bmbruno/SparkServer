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
        private string _validKey = "F9701A3C-080D-49A1-98E6-027FA1D03DDA";

        /// <summary>
        /// Inits IOC and instantiates the controller under testing.
        /// </summary>
        /// <returns></returns>
        private HomeController SetupController()
        {
            this.InitIOC();
            return new HomeController(
                this.GetContainer().GetInstance<IArticleRepository<Article>>(),
                this.GetContainer().GetInstance<IBlogRepository<Blog>>(),
                this.GetContainer().GetInstance<IVideoRepository<Video>>()
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

        [TestMethod]
        public void HomeController_Create_ValidKey()
        {
            HomeController controller = this.SetupController();

            ViewResult result = controller.Create(_validKey) as ViewResult;

            Assert.AreEqual(result.ViewName, "AddEdit");
        }

        [TestMethod]
        public void HomeController_Create_InvalidKey()
        {
            string invalidKey = "12345678-0000-0000-0000-ABCDEF123456";

            HomeController controller = this.SetupController();

            ViewResult result = controller.Create(invalidKey) as ViewResult;

            Assert.IsNull(result);
        }

        [TestMethod]
        public void HomeContrller_Create_AddMode()
        {
            HomeController controller = this.SetupController();

            ViewResult result = controller.Create(_validKey) as ViewResult;
            ArticleAddEditViewModel model = result.Model as ArticleAddEditViewModel;

            Assert.AreEqual(EditMode.Add, model.Mode);
        }

        [TestMethod]
        public void HomeContrller_Create_EditMode()
        {
            HomeController controller = this.SetupController();

            ViewResult result = controller.Edit(_validKey, 1) as ViewResult;
            ArticleAddEditViewModel model = result.Model as ArticleAddEditViewModel;

            Assert.AreEqual(EditMode.Edit, model.Mode);
        }
    }
}
