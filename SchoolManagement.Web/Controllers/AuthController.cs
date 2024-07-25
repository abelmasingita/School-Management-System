using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.AspNetCore.Identity;
using DataAccessLayer.Models;
using static AspnetCoreMvcFull.Models.AuthViewModel;

namespace AspnetCoreMvcFull.Controllers;

public class AuthController : Controller
{
  private readonly UserManager<User> userManager;

  public AuthController(UserManager<User> userManager)
  {
    this.userManager = userManager;
  }

  public IActionResult ForgotPasswordBasic() => View();
  public IActionResult LoginBasic() => View();
  public IActionResult RegisterBasic() => View();

  public async Task<User> Register(RegisterViewModel model)
  {
    try
    {
      User user = new User()
      {
        Email = model.Email,
        UserName = model.Email,
        FirstName = model.FirstName,
        LastName = model.LastName,
        Gender = model.Gender,
        DateOfBirth = model.DateOfBirth,
        Address = model.Address,
        PhoneNumber = model.Phone
      };

      var result = await userManager.CreateAsync(user, model.Password);

      if (result.Succeeded)
      {
        return user;
      }
      else
      {
        return null;
      }
    }
    catch (Exception ex)
    {
      return null;
    }

  }

  [HttpPost]
  public async Task<IActionResult> Login(LoginViewModel model)
  {
    if (ModelState.IsValid)
    {
      //var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

      //if (result.Succeeded)
      //{
      //  return RedirectToAction("Index", "Home");
      //}

      ModelState.AddModelError("", "Invalid login attempt.");
    }

    return View(model);
  }

  [HttpPost]
  public async Task<IActionResult> Logout()
  {
    //await _signInManager.SignOutAsync();
    return RedirectToAction("Index", "Home");
  }

}
