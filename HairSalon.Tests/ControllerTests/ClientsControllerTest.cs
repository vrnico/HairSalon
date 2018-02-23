using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using HairSalon.Controllers;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientsControllerTest
    {
        [TestMethod]
        public void CreateForm_ReturnView_True()
        {
            ClientsController controller = new ClientsController();


            IActionResult clientFormView = controller.CreateForm(1);
            ViewResult result = clientFormView as ViewResult;


            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
