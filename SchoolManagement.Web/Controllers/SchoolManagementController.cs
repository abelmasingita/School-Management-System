using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static AspnetCoreMvcFull.Models.AuthViewModel;

namespace AspnetCoreMvcFull.Controllers;

public class SchoolManagement : Controller
{

  private readonly UserManager<User> userManager;
  private readonly DataLayer db;

  public SchoolManagement(UserManager<User> userManager, DataLayer db)
  {
    this.userManager = userManager;
    this.db = db;
  }
  public IActionResult Class() => View();
  public IActionResult Subject() => View();
  public IActionResult Attendance() => View();
  public IActionResult Fee() => View();
  public IActionResult Grade() => View();

}
