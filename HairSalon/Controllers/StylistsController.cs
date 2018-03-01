using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    [Route("/")]
    public ActionResult Index()
    {
      List<Stylist> allStylists = Stylist.GetAllStylists();
      return View("Index" , allStylists);
    }

    [HttpGet("/stylists/new")]
    public ActionResult CreateStylistForm()
    {
      return View();
    }

    [HttpPost("/stylists")]
    public ActionResult CreateStylist()
    {
      Stylist newStylist = new Stylist(Request.Form["name"]);
      newStylist.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/stylists/{id}")]
    public ActionResult Detail(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylistInput = Stylist.Find(id);
      List<Client> allClients = stylistInput.GetClients();
      model.Add("stylist", stylistInput);
      model.Add("clients", allClients);
      return View(model);
    }

    [HttpPost("/stylists/{id}/clients")]
    public ActionResult CreateClient(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist foundStylist = Stylist.Find(id);
      List<Client> stylistClients = foundStylist.GetClients();
      Client newClient = new Client(Request.Form["new-name"], Request.Form["raw-appt"]);
      newClient.SetStylistId(foundStylist.GetId());
      stylistClients.Add(newClient);
      newClient.Save();
      model.Add("clients", stylistClients);
      model.Add("stylist", foundStylist);
      return View("Detail", model);
    }

    [HttpGet("/stylists/{id}/delete")]
    public ActionResult Delete(int id)
    {
      Stylist thisStylist = Stylist.Find(id);
      thisStylist.Delete();
      return RedirectToAction("Index");
    }


  }
}
