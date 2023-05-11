using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Helper.Services;
using WebApp.ViewModels.Admin;

namespace WebApp.Controllers;
[Authorize(Roles ="admin")]
[Route("admin")]
public class AdminController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
	

	
}
