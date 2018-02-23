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
      Stylist newStylist = new Stylist("Lynda", "1/1/0001 12:00:00 AM", 1);
      string testName = "Lynda";
      string testDate = "1/1/0001 12:00:00 AM";
      int testId = 1;


      string inputName = newStylist.GetName();
      string inputDate = newStylist.GetRawDate();
      int nullId = newStylist.GetId();

      Assert.AreEqual(testName, inputName);
      Assert.AreEqual(testDate, inputDate);
      Assert.AreEqual(testId, nullId);
    }
  }
}
