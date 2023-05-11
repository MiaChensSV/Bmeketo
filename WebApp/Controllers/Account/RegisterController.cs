using Microsoft.AspNetCore.Mvc;
using WebApp.Helper.Services;
using WebApp.ViewModels.Account;
using WebApp.ViewModels.Admin;

namespace WebApp.Controllers;

public class RegisterController : Controller
{
	private readonly AuthService _auth;
	private readonly UserService _userService;

	public RegisterController(AuthService auth, UserService userService)
	{
		_auth = auth;
		_userService = userService;
	}

	public IActionResult Index()
	{
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> Index(RegistrationViewModel viewmodel)
	{
		if(ModelState.IsValid)
		{
			if(await _auth.UserExistAsync(x=>x.Email==viewmodel.Email))
			{
				ModelState.AddModelError("", "Email is already exist");
			}
			else
			{
				var _user = await _auth.RegisterUserAsync(viewmodel);
				if (_user!=null)
					if(viewmodel.ImageFile!=null)
					{
						await _userService.UploadImageAsync(_user,viewmodel.ImageFile);
					}
					return RedirectToAction("Index", "Login");
			}
			
		}
		ModelState.AddModelError("", "Invaild input");
		return View(viewmodel);
	}	
}
