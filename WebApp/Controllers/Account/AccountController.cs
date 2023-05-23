using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Helper.Services;
using WebApp.ViewModels.Account;

namespace WebApp.Controllers.Account;
[Authorize]
public class AccountController : Controller
{
	private readonly UserService _userService;

	public AccountController(UserService userService)
	{
		_userService = userService;
	}

	public IActionResult Index()
	{
		return View();
	}
	[HttpGet]
	[Route("MyAccount/{id}")]
	public IActionResult MyAccount(string id)
	{
		var _user = _userService.GetAsync(id).Result;

		var _userViewModel = new UserViewModel
		{
			FirstName = _user.FirstName,
			LastName = _user.LastName,
			Email = _user.Email,
			CompanyName = _user.CompanyName,
			City = _user.City,
			StreetName = _user.StreetName,
			ProfileImageUrl = _user.ProfileImageUrl,
			PostalCode = _user.PostalCode,
			PhoneNumber= _user.PhoneNumber,
		};
		return View(_userViewModel);
	}

	[HttpPost]
	[Route("MyAccount/{id}")]
	public IActionResult MyAccount(UserViewModel viewmodel)
	{

		var _user = _userService.UpdateAsync(viewmodel);
		
		return View(_user);
	}


}