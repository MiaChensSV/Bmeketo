using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers.Account;
[Authorize]
public class AccountController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
