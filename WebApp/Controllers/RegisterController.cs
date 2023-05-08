using Microsoft.AspNetCore.Mvc;
using WebApp.Helper.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class RegisterController : Controller
{
	private readonly AuthService _auth;

	public RegisterController(AuthService auth)
	{
		_auth = auth;
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
			if (await _auth.RegisterUserAsync(viewmodel))
				return RedirectToAction("Index", "Login");
		}
		ModelState.AddModelError("", "Invaild input");
		return View(viewmodel);
	}
}
