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


            IActionResult clientFormView = controller.CreateClientForm(1);
            ViewResult result = clientFormView as ViewResult;


            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod]
        public void Detail_ReturnView_True()
        {
            ClientsController controller = new ClientsController();


            IActionResult clientDetailView = controller.Detail(1);
            ViewResult result = clientDetailView as ViewResult;


            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod]
        public void UpdateForm_ReturnView_True()
        {
            ClientsController controller = new ClientsController();


            IActionResult clientUpdateFormView = controller.UpdateForm(1);
            ViewResult result = clientUpdateFormView as ViewResult;


            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
