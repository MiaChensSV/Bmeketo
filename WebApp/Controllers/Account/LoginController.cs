using Microsoft.AspNetCore.Mvc;
using WebApp.Helper.Services;
using WebApp.ViewModels.Account;

namespace WebApp.Controllers.Account;

public class LoginController : Controller
{
    private readonly AuthService _auth;

    public LoginController(AuthService auth)
    {
        _auth = auth;
    }

    public IActionResult Index(string ReturnUrl = null!)
    {
        var viewmodel = new LoginViewModel();
        if (ReturnUrl != null)
        {
            viewmodel.ReturnUrl = ReturnUrl;
        }
        return View(viewmodel);
    }
    [HttpPost]
    public async Task<IActionResult> IndexAsync(LoginViewModel viewmodel)
    {
        if (ModelState.IsValid)
        {
            if (await _auth.LoginAsync(viewmodel))
            {
                return LocalRedirect(viewmodel.ReturnUrl);
            }
            ModelState.AddModelError("", "Invaild email or password");
        }
        return View(viewmodel);
    }
}
