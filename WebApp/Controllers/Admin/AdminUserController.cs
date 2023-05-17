using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Identity;
using WebApp.ViewModels.Admin.Users;

namespace WebApp.Controllers.Admin;
[Route("admin/users")]
public class AdminUserController : Controller
{
	private readonly UserManager<AppIdentityUser> _userManager;

	public AdminUserController(UserManager<AppIdentityUser> userManager)
	{
		_userManager = userManager;
	}

	public async Task<IActionResult> Index()
	{
		var users = await _userManager.GetUsersInRoleAsync("user");
		var admins = await _userManager.GetUsersInRoleAsync("admin");

		var viewmodel = new AdminUsersViewModel
		{
			Users = users,
			Admins = admins,
		};

		return View(viewmodel);
	}
}
