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
        public void Index_ReturnIfView_True()
        {

            StylistsController controller = new StylistsController();


            IActionResult indexView = controller.Index();
            ViewResult result = indexView as ViewResult;


            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
      }
