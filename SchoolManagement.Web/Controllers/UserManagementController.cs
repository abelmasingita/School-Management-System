using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

    ViewBag.Roles = new SelectList(await db.Roles.ToListAsync(), "Id", "Name");
    return View(model);
  }

  [HttpPost]
  public async Task<IActionResult> AddUser(CompositeViewModel model)
  {
    ModelState.Remove("RegisterVM.Password");
    ModelState.Remove("RegisterVM.ConfirmPassword");
    var role = await db.Roles.FindAsync(model.RegisterVM.Role);

    if (role.Name == "Teacher")
    {
      ModelState.Remove("ParentVM");
      ModelState.Remove("StudentVM");
    }
    else if (role.Name == "Student")
    {
      ModelState.Remove("ParentVM");
      ModelState.Remove("TeacherVM");
    }
    else if (role.Name == "Parent")
    {
      ModelState.Remove("StudentVM");
      ModelState.Remove("TeacherVM");
      ModelState.Remove("ParentVM");
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

          if (model.RegisterVM.Role == "teacher")
          {
            Teacher teacher = new Teacher()
            {
              UserId = user.Id,
            };

            db.Teachers.Add(teacher);
            db.SaveChanges();


          }
          else if (model.RegisterVM.Role == "student")
          {

            Student student = new Student()
            {
              UserId = user.Id,
              AdmissionDate = model.StudentVM.AdmissionDate,
              ParentId = int.Parse(model.StudentVM.Parent),
              GradeId = int.Parse(model.StudentVM.Class),
            };

            db.Students.Add(student);
            db.SaveChanges();

          }
          else if (model.RegisterVM.Role == "parent")
          {
            Parent parent = new Parent()
            {
              UserId = user.Id,
            };

            db.Parents.Add(parent);
            db.SaveChanges();
          }


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
        #region Class_Parents
        ViewBag.Classes = new SelectList(db.Grades, "Id", "GradeName");
        ViewBag.Parents = db.Parents.Include(p => p.User).Select(p => new SelectListItem { Text = p.User.FirstName + " " + p.User.LastName, Value = p.Id.ToString() }).ToList();
        #endregion
        return PartialView("~/Views/Shared/_StudentFields.cshtml", model);
      //case "parent":
      //  return PartialView("~/Views/Shared/_ParentFields.cshtml", model);
      default:
        return Content(string.Empty);
    }
  }

  public async Task<IActionResult> Details(string id)
  {
    User user = await db.Users.FirstOrDefaultAsync(u => u.Id == id);

    model.RegisterVM = new RegisterViewModel() { Role = string.Empty };
    model.TeacherVM = new TeacherViewModel();
    model.StudentVM = new StudentViewModel();
    model.ParentVM = new ParentViewModel();


    return View(user);
  }

  [HttpPost]
  public async Task<IActionResult> Details()
  {
   
    return View();
  }
}
