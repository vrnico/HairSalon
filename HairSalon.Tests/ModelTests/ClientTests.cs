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

  }
}
