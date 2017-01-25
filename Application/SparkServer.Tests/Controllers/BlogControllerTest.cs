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
    public class BlogControllerTest : TestBase
    {
        private string _uniqueURL = "blog-number-one";

        /// <summary>
        /// Inits IOC and instantiates the controller under testing.
        /// </summary>
        /// <returns></returns>
        private BlogController SetupController()
        {
            this.InitIOC();
            return new BlogController(this.GetContainer().GetInstance<IBlogRepository<Blog>>(), this.GetContainer().GetInstance<ICategoryRepository<Category>>());
        }

        [TestMethod]
        public void BlogController_Index_Overview_All()
        {
            // Arrange
            BlogController controller = this.SetupController();

            // Act
            ViewResult result = controller.Index(null, null) as ViewResult;
            BlogListViewModel viewModel = result.Model as BlogListViewModel;

            // Assert
            Assert.AreEqual(ViewMode.Overview, viewModel.ViewMode);
            Assert.IsNotNull(viewModel);
        }

        [TestMethod]
        public void BlogController_Index_List_Year()
        {
            // Arrange
            BlogController controller = this.SetupController();

            // Act
            ViewResult result = controller.Index(2017, null) as ViewResult;
            BlogListViewModel viewModel = result.Model as BlogListViewModel;

            // Assert
            Assert.AreEqual(ViewMode.List, viewModel.ViewMode);
            Assert.IsNotNull(viewModel);
        }

        [TestMethod]
        public void BlogController_Index_List_YearMonth()
        {
            // Arrange
            BlogController controller = this.SetupController();

            // Act
            ViewResult result = controller.Index(2017, 1) as ViewResult;
            BlogListViewModel viewModel = result.Model as BlogListViewModel;

            // Assert
            Assert.AreEqual(ViewMode.List, viewModel.ViewMode);
            Assert.IsNotNull(viewModel);
        }

    }
}
