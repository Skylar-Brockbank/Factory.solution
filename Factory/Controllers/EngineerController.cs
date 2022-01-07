using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public ActionResult Edit(int id)
    {
      //get the specified engineer and prepare a select list for adding machines
      //you're gonna add a textbox for name so that you can change the name property
      Engineer target = _db.Engineers
        .Include(engineer => engineer.Machines)
        .ThenInclude(join => join.Machine)
        .FirstOrDefault(engineer => engineer.EngineerId == id);
      ViewBag.SelectMachines = new SelectList(_db.Machines,"MachineId", "DeviceName");
      return View(target);
    }
    [HttpPost]
    public ActionResult Edit(Engineer e, int SelectMachines)
    {
      _db.Entry(e).State = EntityState.Modified;
      _db.SaveChanges();
      if(SelectMachines != 0)
      {
        _db.EngineerMachines.Add(new EngineerMachine() {EngineerId = e.EngineerId, MachineId = SelectMachines});
      }
      _db.SaveChanges();
      return RedirectToAction("Detail", new{id = e.EngineerId});
    }
  }
}