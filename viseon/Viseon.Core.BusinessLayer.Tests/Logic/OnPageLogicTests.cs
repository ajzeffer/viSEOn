using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Viseon.Core.BusinessLayer.Logic.OnPage;

namespace Viseon.Core.BusinessLayer.Tests.Logic
{
    [TestClass]
    public class OnPageLogicTests
    {
        [TestMethod]
        public async Task BuildOnPageTest()
        {
            var test = await new OnPageLogic().BuildOnPageModel("");
            Assert.IsNotNull(test); 
        }
    }
}
