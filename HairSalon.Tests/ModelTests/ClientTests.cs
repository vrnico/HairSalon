using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTests : IDisposable
  {
    public void Dispose()
    {
      Client.DeleteAll();
      Stylist.DeleteAll();
    }

    public ClientTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=nico_daunt_test";
    }
    [TestMethod]
        public void GetClient_TakesInput_ReturnsInput()
        {
          Client newClient = new Client("Bob", "1/1/0001 12:00:00 AM", 1, 1);
          string testName = "Bob";
          string testAppt = "1/1/0001 12:00:00 AM";
          int testId = 1;
          int testStylistId = 1;

          string inputName = newClient.GetName();
          string inputAppt = newClient.GetRawAppt();
          int nullId = newClient.GetId();
          int nullStylistId = newClient.GetStylistId();

          Assert.AreEqual(testName, inputName);
          Assert.AreEqual(testAppt, inputAppt);
          Assert.AreEqual(testId, nullId);
          Assert.AreEqual(testStylistId, nullStylistId);
        }

    [TestMethod]
      public void GetAppt_AssignAppt_SetAppt()
      {
        Client testClient = new Client("Bob", "1991-05-05");
        DateTime testAppt = new DateTime(1991, 06, 05);

        testClient.SetAppt();
        DateTime inputAppt = testClient.GetFormattedAppt();

        Assert.AreEqual(inputAppt, testAppt);
      }

      [TestMethod]
        public void AssignClient_SavesClienttoStylist_ReturnsClientInfo()
        {

        }

  }
}
