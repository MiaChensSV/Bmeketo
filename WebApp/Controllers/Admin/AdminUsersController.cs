using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels.Admin.Users;

namespace WebApp.Controllers.Admin;

public class AdminUsersController : Controller
{
    private readonly UserManager<IdentityBuilder> _userManager;

    public AdminUsersController(UserManager<IdentityBuilder> userManager)
    {
        _userManager = userManager;
    }

    //public async Task<IActionResult> IndexAsync()
    //{
    //    var viewModel=new AdminUsersViewModel
    //    {
    //        Users= await _userManager.GetUsersInRoleAsync("user"),
    //};
    //    var _admin = await _userManager.GetUsersInRoleAsync("admin");
    //    return View(viewModel);
    //}
}
