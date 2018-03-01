using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using HairSalon.Controllers;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistsControllerTest
    {
        [TestMethod]
        public void Index_ReturnView_True()
        {

            StylistsController controller = new StylistsController();


            IActionResult indexView = controller.Index();
            ViewResult test = indexView as ViewResult;


            Assert.IsInstanceOfType(test, typeof(ViewResult));
        }

      [TestMethod]
      public void CreateStylistForm_ReturnIfView_True()
      {
       StylistsController controller = new StylistsController();

       IActionResult stylistsCreate = controller.CreateStylistForm();
       ViewResult test = stylistsCreate as ViewResult;

       Assert.IsInstanceOfType(test, typeof(ViewResult));
      }

      [TestMethod]
      public void Detail_ReturnView_True()
      {
          StylistsController controller = new StylistsController();


          IActionResult stylistDetailView = controller.Detail(1);
          ViewResult result = stylistDetailView as ViewResult;


          Assert.IsInstanceOfType(result, typeof(ViewResult));
      }

    }
}
