using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Helper.Services;
using WebApp.Models;
using WebApp.Models.Identity;
using WebApp.Services;
using WebApp.ViewModels.Account;
using WebApp.ViewModels.Admin.Users;

namespace WebApp.Controllers.Admin;
public class AdminUserController : Controller
{
	private readonly UserManager<AppIdentityUser> _userManager;
	private readonly RoleManager<IdentityRole> _roleManager;
	private readonly AuthService _auth;
	private readonly UserService _userService;
	private readonly AddressService _addressService;


	public AdminUserController(UserManager<AppIdentityUser> userManager, AuthService auth, UserService userService, RoleManager<IdentityRole> roleManager, AddressService addressService)
	{
		_userManager = userManager;
		_auth = auth;
		_userService = userService;
		_roleManager = roleManager;
		_addressService = addressService;
	}

	[Route("admin/users")]
	public async Task<IActionResult> Index()
	{
		return View(await _userManager.Users.ToListAsync());
	}

	[HttpGet]
	[Route("admin/users/create")]
	public async Task<IActionResult> CreateAsync()
	{
		List<IdentityRole> identityRoleList = await _roleManager.Roles.ToListAsync();
		return View();
	}

	[HttpPost]
	[Route("admin/users/create")]
	public async Task<IActionResult> Create(RegistrationViewModel viewmodel)
	{
		if (ModelState.IsValid)
		{
			if (await _auth.UserExistAsync(x => x.Email == viewmodel.Email))
			{
				ModelState.AddModelError("", "Email is already exist");
			}
			else
			{
				var _user = await _userService.CreateUserAsync(viewmodel);
				if (_user != null)
					if (viewmodel.ImageFile != null)
					{
						await _userService.UploadImageAsync(_user, viewmodel.ImageFile);
					}
				return RedirectToAction("Index", "AdminUser");
			}

		}
		ModelState.AddModelError("", "Invaild input");
		return View(viewmodel);
	}

	[HttpGet]
	[Route("admin/users/edit/{id}")]
	public async Task<IActionResult> EditAsync(string id)
	{
		return View(await _userService.GetAsync(id));
	}

	[HttpPost]
	[Route("admin/users/edit/{id}")]
	public async Task<IActionResult> EditAsync(UserViewModel viewmodel)
	{

		await _userService.UpdateAsync(viewmodel);
				
		return RedirectToAction("Index", "AdminUser");
	}
}
