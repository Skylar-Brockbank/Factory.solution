using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Factory.Models;
using System.Linq;

namespace Factory.Controllers
{
  public class EngineerController : Controller
  {
    private readonly skylar_brockbankContext _db;
    public EngineerController(skylar_brockbankContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      ViewBag.EngineerList = _db.Engineers.ToList();
      return View();
    }
  }
}