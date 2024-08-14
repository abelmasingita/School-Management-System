using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static AspnetCoreMvcFull.Models.AuthViewModel;
using static AspnetCoreMvcFull.Models.SchoolViewModel;

namespace AspnetCoreMvcFull.Controllers;

public class ScheduleController : Controller
{

  private readonly UserManager<User> userManager;
  private readonly DataLayer db;

  public ScheduleController(UserManager<User> userManager, DataLayer db)
  {
    this.userManager = userManager;
    this.db = db;
  }
  public IActionResult Index()
  {
    Event model = new Event();
    return View(model);
  }

  [HttpGet]
  public List<Event> GetEvents()
  {
    List<Event> events = db.Events.ToList();

    return events;
  }

  [HttpPost]
  public void AddEvent(Event data)
  {
    db.Events.Add(data);
    db.SaveChanges();
  }

  [HttpPost]
  public IActionResult EditEvent(Event data)
  {
    var toUpdate = db.Events.Where(e => e.id == data.id).FirstOrDefault();
    if (toUpdate != null)
    {
      toUpdate.title = data.title;
      toUpdate.start = data.start;
      toUpdate.end = data.end;
      toUpdate.allDay = data.allDay;

      db.Entry(toUpdate).State = EntityState.Modified;
      db.SaveChanges();
    }

    return View("Index");
  }
}
