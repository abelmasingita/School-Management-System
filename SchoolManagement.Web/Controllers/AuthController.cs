using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.AspNetCore.Identity;
using DataAccessLayer.Models;
using static AspnetCoreMvcFull.Models.AuthViewModel;

namespace AspnetCoreMvcFull.Controllers;

public class AuthController : Controller
{
  private readonly UserManager<User> userManager;
  private readonly SignInManager<User> signInManager;

  public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
  {
    this.userManager = userManager;
    this.signInManager = signInManager;
  }

  public IActionResult ForgotPassword() => View();
  public IActionResult Login() => View();

  [HttpPost]
  public async Task<IActionResult> Login(LoginViewModel model)
  {
    if (ModelState.IsValid)
    {
      var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

      if (result.Succeeded)
      {
        var user = await userManager.FindByEmailAsync(model.Email);
        if (user is null)
        {
          TempData["TempError"] = "User do not exist. Please try again.";
        }
        var role = await userManager.GetRolesAsync(user);

        if (role.Contains("Admin"))
        {
          //TempData["TempSuccess"] = "Logged In";
          return RedirectToAction("Admin", "Dashboards");
        }
        else if (role.Contains("Student"))
        {
          //TempData["TempSuccess"] = "Logged In";
          return RedirectToAction("Student", "Dashboards");
        }
        else if (role.Contains("Teacher"))
        {
          //TempData["TempSuccess"] = "Logged In";
          return RedirectToAction("Teacher", "Dashboards");
        }
        else if (role.Contains("Parent"))
        {
          //TempData["TempSuccess"] = "Logged In";
          return RedirectToAction("Parent", "Dashboards");
        }

      }
      else if (result.IsLockedOut)
      {
        TempData["TempError"] = "Account is Locked";
        return View("LockOut");
      }
      else
      {
        TempData["TempError"] = "Invalid Login credentials. Please try again.";
        return View("Login");
      }
    }

    return View(model);
  }

  public async Task<IActionResult> Logout()
  {
    await signInManager.SignOutAsync();
    return RedirectToAction("Login", "Auth");
  }

}
