using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class StylistController : Controller
  {
    [Route("/")]
    public ActionResult Index()
    {
      List<Stylist> allStylists = Stylist.GetAll();
      return View("Index", allStylists);
    }

  }
}
