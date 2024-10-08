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
        return RedirectToAction("Index", "Dashboards");
      }
      else
      {
        //display the reason of login failure
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
