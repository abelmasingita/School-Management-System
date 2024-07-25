using AspnetCoreMvcFull.Models;
using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static AspnetCoreMvcFull.Models.AuthViewModel;

namespace AspnetCoreMvcFull.Controllers;

public class UserManagementController : Controller
{

  private readonly UserManager<User> userManager;
  private readonly DataLayer db;
  private readonly IConfiguration configuration;
  private CompositeViewModel model = new CompositeViewModel();

  public UserManagementController(UserManager<User> userManager, DataLayer db, IConfiguration configuration)
  {
    this.userManager = userManager;
    this.db = db;
    this.configuration = configuration;
  }

  public async Task<IActionResult> Index()
  {
    List<User> users = await db.Users.ToListAsync();

    return View(users);
  }

  public async Task<IActionResult> AddUser()
  {

    model.RegisterVM = new RegisterViewModel() { Role = string.Empty };
    model.TeacherVM = new TeacherViewModel();
    model.StudentVM = new StudentViewModel();
    model.ParentVM = new ParentViewModel();

    return View(model);
  }

  [HttpPost]
  public async Task<IActionResult> AddUser(CompositeViewModel model)
  {
    ModelState.Remove("RegisterVM.Password");
    ModelState.Remove("RegisterVM.ConfirmPassword");

    if (model.RegisterVM.Role == "teacher")
    {
      ModelState.Remove("ParentVM");
      ModelState.Remove("StudentVM");
    }
    else if (model.RegisterVM.Role == "teacher")
    {
      ModelState.Remove("ParentVM");
      ModelState.Remove("StudentVM");
    }

    if (ModelState.IsValid)
    {
      try
      {
        model.RegisterVM.Password = configuration.GetValue<string>("AppSettings:Password");

        User user = new User
        {
          Email = model.RegisterVM.Email,
          UserName = model.RegisterVM.Email,
          FirstName = model.RegisterVM.FirstName,
          LastName = model.RegisterVM.LastName,
          Gender = model.RegisterVM.Gender,
          DateOfBirth = model.RegisterVM.DateOfBirth,
          Address = model.RegisterVM.Address,
          PhoneNumber = model.RegisterVM.Phone
        };

        var result = await userManager.CreateAsync(user, model.RegisterVM.Password);
        if (result.Succeeded)
        {
          TempData["Success"] = true;
          TempData["Message"] = "User created successfully!";
        }
        else
        {
          TempData["Success"] = false;
          TempData["Message"] = "User Not Created!";
        }
      }
      catch (Exception ex)
      {
        TempData["Success"] = false;
        TempData["Message"] = ex.Message;
      }
    }

    return View();
  }

  [HttpGet]
  public IActionResult GetRoleSpecificFields(string role)
  {
    switch (role.ToLower())
    {
      case "teacher":
        return PartialView("~/Views/Shared/_TeacherFields.cshtml", model);
      case "student":
        return PartialView("~/Views/Shared/_StudentFields.cshtml", model);
      case "parent":
        return PartialView("~/Views/Shared/_ParentFields.cshtml", model);
      default:
        return Content(string.Empty);
    }
  }

  public async Task<IActionResult> Edit(string id)
  {
    
    return View();
  }
  public async Task<IActionResult> Details(string id)
  {

    return View();
  }
}
