using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcContrib.TestHelper;
using Viseon.Apps.MvcClient.Controllers;
using Viseon.Apps.MvcClient.Tests.Data;

namespace Viseon.Apps.MvcClient.Tests.Controllers
{
    [TestClass]
    public class ResultControllerTest
    {
        [TestMethod]
        public async Task ValidUrl()
        {
            var controller = new ResultController();

            // Act
            var result = await controller.Overview(TestData.ValidUrl);

            // Assert
            Assert.IsNotNull(result);
            
        }

        [TestMethod]
        public async Task InValidUrl()
        {
            var controller = new ResultController();

            // Act
            var result = await  controller.Overview(TestData.InvalidUrl);

            result.AssertHttpRedirect()
                .Url.ShouldBe("~/"); 
            
        }

        [TestMethod]
        public async Task EmptyUrl()
        {
            var controller = new ResultController();

            // Act
            var result = await controller.Overview(TestData.EmptyVal);
            result
                .AssertHttpRedirect()
                .Url.ShouldBe("~/"); 

        }
    }
}
