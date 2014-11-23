using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Api;
using Api.Controllers;
using System.Web.Http.Results;

namespace Api.Tests.Controllers
{
    [TestClass]
    public class MyApiControllerTest
    {
        [TestMethod]
        public void Find_a_node_of_tree_that_it_exists()
        {
            // Arrange
            MyApiController controller = new MyApiController();

            var result = controller.Get(40, "") as OkNegotiatedContentResult<int>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(184, result.Content);
        }
    }
}
