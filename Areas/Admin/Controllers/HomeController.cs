using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Highscore.Data;

namespace Highscore.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Administrator")]
public class HomeController : Controller
{

   [Area("Admin")]
   [Authorize(Roles = "Administrator")]
   public IActionResult Index()
   {
      return View();
   }
}
