using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {

    [HttpGet("/stylists/{stylistID}/clients/new")]
    public ActionResult CreateClientForm(int stylistId)
    {
      Stylist foundstylist = Stylist.Find(stylistId);
      return View(foundstylist);
    }




    [HttpGet("/clients/{id}")]
    public ActionResult Detail(int id)
    {
      Client item = Client.Find(id);
      return View(item);
    }

    [HttpGet("/clients/{id}/update")]
    public ActionResult UpdateForm(int id)
    {
      Client thisItem = Client.Find(id);
      return View(thisItem);
    }

    [HttpGet("/clients/{id}/delete")]
    public ActionResult DeleteItem(int id)
    {
      Client thisItem = Client.Find(id);
      thisItem.Delete();
      return RedirectToAction("Detail", "stylists", new {Id = thisItem.GetStylistId()});
    }
  }
}
