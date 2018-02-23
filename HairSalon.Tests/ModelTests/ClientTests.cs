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
          Client newClient = new Client("Bob");
          string testName = "Bob";

          string inputName = newClient.GetName();

          Assert.AreEqual(testName, inputName);
        }

  }
}
