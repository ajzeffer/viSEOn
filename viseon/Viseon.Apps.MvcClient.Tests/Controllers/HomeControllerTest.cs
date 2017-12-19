using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Viseon.Apps.MvcClient.Controllers;

namespace Viseon.Apps.MvcClient.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

         

         
    }
}
