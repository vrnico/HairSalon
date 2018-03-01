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
    public void Equals_ReturnsTrueIfNamesAreTheSame_Recipe()
    {
      // Arrange
      Stylist firstStylist = new Stylist("Lynda");
      Stylist secondStylist = new Stylist("Lynda");

      //Act
      firstStylist.Save();
      secondStylist.Save();

    // Assert
    Assert.AreEqual(true, firstStylist.GetName().Equals(secondStylist.GetName()));
  }

    [TestMethod]
    public void Find_FindsStylistInDatabase_Stylist()
    {
      //Arrange
      Stylist testStylist = new Stylist("Lynda");;
      testStylist.Save();

      //Act
      Stylist foundStylist = Stylist.Find(testStylist.GetId());

      //Assert
      Assert.AreEqual(testStylist.GetId(), foundStylist.GetId());
    }

    [TestMethod]
    public void Delete_DeleteAllStylistsInDatabase_void()
    {
      //arrange
       Stylist newStylist = new Stylist("Lynda");

       //act
       Stylist.DeleteAll();
       int result = Stylist.GetAllStylists().Count;

       //assert
       Assert.AreEqual(0, result);
    }

  }
}
