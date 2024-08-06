using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.AspNetCore.Authorization;

namespace AspnetCoreMvcFull.Controllers;

//[Authorize(Roles = "Admin")]
[Authorize]
public class DashboardsController : Controller
{
  public IActionResult Index() => View();
}
