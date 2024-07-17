using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.AspNetCore.Identity;
using DataAccessLayer.Models;

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

  public IActionResult ForgotPasswordBasic() => View();
  public IActionResult LoginBasic() => View();
  public IActionResult RegisterBasic() => View();

  [HttpPost]
  public async Task<IActionResult> Register(AuthViewModel.Register model)
  {

    if (ModelState.IsValid)
    {
      User user = new User()
      {
        Email = model.Email,
        UserName = model.Email,
        FirstName = model.FirstName,
        LastName = model.LastName,

      };

      var result = await userManager.CreateAsync(user, model.PassWord);



    }


    return View();
  }
}
