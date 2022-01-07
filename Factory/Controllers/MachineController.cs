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
    public ActionResult Detail(int id)
    {
      Machine target = _db.Machines
        .Include(m=>m.LicensedEngineers)
        .ThenInclude(join=>join.Engineer)
        .FirstOrDefault(m=>m.MachineId==id);
      return View(target);
    }
    public ActionResult Edit(int id)
    {
      Machine target = _db.Machines
        .Include(m=>m.LicensedEngineers)
        .ThenInclude(join=>join.Engineer)
        .FirstOrDefault(m=>m.MachineId==id);
      ViewBag.SelectEngineer = new SelectList(_db.Engineers, "EngineerId", "EngineerName");
      return View(target);
    }
    [HttpPost]
    public ActionResult Edit(Machine m, int SelectEngineer)
    {
      _db.Entry(m).State = EntityState.Modified;
      _db.SaveChanges();
      if(SelectEngineer != 0)
      {
        _db.EngineerMachines.Add(new EngineerMachine(){EngineerId = SelectEngineer, MachineId = m.MachineId});
        _db.SaveChanges();
      }
      return RedirectToAction("Detail",new {id = m.MachineId});
    }
    public ActionResult RemoveEngineer(int id)
    {
      EngineerMachine target = _db.EngineerMachines.FirstOrDefault(em=>em.EngineerMachineId==id);
      _db.Remove(target);
      _db.SaveChanges();
      return RedirectToAction("Detail", new{id=target.MachineId});
    }
  }
}