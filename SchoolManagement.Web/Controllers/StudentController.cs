using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static AspnetCoreMvcFull.Models.AuthViewModel;

namespace AspnetCoreMvcFull.Controllers;

public class StudentController : Controller
{

  private readonly UserManager<User> userManager;
  private readonly DataLayer db;
  private readonly IConfiguration configuration;
  private CompositeViewModel model = new CompositeViewModel();

  public StudentController(UserManager<User> userManager, DataLayer db, IConfiguration configuration)
  {
    this.userManager = userManager;
    this.db = db;
    this.configuration = configuration;
  }

  public async Task<IActionResult> Index()
  {
    var students = await db.Users
        .Include(u => u.Student) 
        .Where(u => u.Student != null)
        .ToListAsync();

    return View(students);
  }

  public async Task<IActionResult> Details()
  {
    List<User> users = await db.Users.ToListAsync();

    return View(users);
  }
  public async Task<IActionResult> Promotion()
  {
    List<User> users = await db.Users.ToListAsync();

    return View(users);
  }
  public async Task<IActionResult> StudentList()
  {
    var students = await db.Users
        .Include(u => u.Student)
        .Where(u => u.Student != null)
        .ToListAsync();

    return View(students);
  }
}
