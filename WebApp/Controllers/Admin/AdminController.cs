using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Helper.Services;
using WebApp.Models.Identity;
using WebApp.ViewModels.Admin;

namespace WebApp.Controllers;
[Authorize(Roles = "admin,manager")]
[Route("admin")]
public class AdminController : Controller
{
	private readonly ContactService _contactService;
	private readonly UserManager<AppIdentityUser> _userManager;

	public AdminController(ContactService contactService, UserManager<AppIdentityUser> userManager)
	{
		_contactService = contactService;
		_userManager = userManager;
	}

	public async Task<IActionResult> Index()
	{
		var viewmodel = new AdminViewModel
		{
			Users = await _userManager.GetUsersInRoleAsync("user"),
			ContactIssues = await _contactService.GetAllAsync(),
		};
		return View(viewmodel);
	}	
}
