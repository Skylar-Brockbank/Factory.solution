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
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Engineer e)
    {
      _db.Engineers.Add(e);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Detail(int id)
    {
      Engineer target = _db.Engineers
        .Include(engineer => engineer.Machines)
        .ThenInclude(join => join.Machine)
        .FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(target);
    }
  }
}