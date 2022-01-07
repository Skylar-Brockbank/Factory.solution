using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class MachineController : Controller
  {
    private readonly skylar_brockbankContext _db;
    public MachineController(skylar_brockbankContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Machine> list = _db.Machines.ToList();
      return View(list);
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Machine m)
    {
      _db.Machines.Add(m);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}