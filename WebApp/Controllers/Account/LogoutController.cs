using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Identity;

namespace WebApp.Controllers.Account;

public class LogoutController : Controller
{
    private readonly SignInManager<AppIdentityUser> _signInManager;

    public LogoutController(SignInManager<AppIdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task<IActionResult> Index()
    {
        if (_signInManager.IsSignedIn(User))
            await _signInManager.SignOutAsync();
        return LocalRedirect("/");
    }
}
