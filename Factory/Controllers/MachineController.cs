using Microsoft.AspNetCore.Mvc;

namespace Factory.Controllers
{
  public class MachineController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }
  }
}