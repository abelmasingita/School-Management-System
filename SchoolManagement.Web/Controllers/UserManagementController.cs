using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;

namespace AspnetCoreMvcFull.Controllers;

public class UserManagementController : Controller
{
  public IActionResult Teacher() => View();
  public IActionResult Parent() => View();
  public IActionResult Student() => View();

}
