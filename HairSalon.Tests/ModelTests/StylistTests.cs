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
      Stylist.DeleteAll();
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

    [TestMethod]
      public void GetDate_AssignDate_SetDate()
      {
        Stylist testStylist = new Stylist("Lynda", "1992-02-25");
        DateTime testDate = new DateTime(1992, 02, 25);

        testStylist.SetDate();
        DateTime inputDate = testStylist.GetFormattedDate();

        Assert.AreEqual(inputDate, testDate);
      }

    [TestMethod]
      public void AssignStylist_SavesStylisttoStylist_ReturnsStylistInfo()
      {
        Stylist newStylist = new Stylist("Lynda", "1992-02-25");
         newStylist.Save();
         Client newClient = new Client("Bob", "1992-02-25");
         newClient.SetStylistId(newStylist.GetId());
         // newClient.Save();
         Client testClient = new Client("Louise", "1992-02-25");;
         testClient.SetStylistId(newStylist.GetId());
         testClient.Save();
         List<Client> testList = new List<Client>{newClient, testClient};

         List<Client> result = newStylist.GetClients();

         CollectionAssert.AreEqual(result, testList);

      }
  }
}
