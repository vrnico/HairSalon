using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTests : IDisposable
  {
    public void Dispose()
    {
      Client.DeleteAll();
      Stylist.DeleteAll();
    }

    public StylistTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=nico_daunt_test";
    }

    [TestMethod]
    public void GetSytlist_TakesInput_ReturnsInput()
    {
      Stylist newStylist = new Stylist("Lynda");
      string testName = "Lynda";

      string inputName = newStylist.GetName();

      Assert.AreEqual(testName, inputName);
    }
  }
}
