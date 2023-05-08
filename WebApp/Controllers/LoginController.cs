using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class LoginController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
	public IActionResult Index(LoginViewModel viewmodel)
	{
        if(ModelState.IsValid)
        {
			return View();

		}
		
            ModelState.AddModelError("", "Invaild email or password");
			return View(viewmodel);

		
	}
}
