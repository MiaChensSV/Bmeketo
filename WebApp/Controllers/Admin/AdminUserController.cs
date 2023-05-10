using Microsoft.AspNetCore.Mvc;
using WebApp.Helper.Services;

namespace WebApp.Controllers.Admin;
[Route("admin/users")]
public class AdminUserController : Controller
{
	private readonly UserService _userService;

	public AdminUserController(UserService userService)
	{
		_userService = userService;
	}

	public async Task<IActionResult> Index()
	{
		return View(await _userService.GetAllAsync());
	}
}
