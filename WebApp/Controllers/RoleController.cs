using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Identity;
using WebApp.ViewModels;

namespace WebApp.Controllers;
[Authorize(Roles = "admin")]

public class RoleController : Controller
{
	private readonly RoleManager<IdentityRole> _roleManager;
	private readonly UserManager<AppIdentityUser> _userManager;

	public RoleController(RoleManager<IdentityRole> roleManager, UserManager<AppIdentityUser> userManager)
	{
		_roleManager = roleManager;
		_userManager = userManager;
	}

	public async Task<IActionResult> Index()
	{
		return View(await _roleManager.Roles.ToListAsync());
	}


	[Route("/role/edit/{id}")]
	public async Task<IActionResult> EditAsync(string id)
	{
		ViewBag.Type = "Edit";
		var _roleModel = await _roleManager.FindByIdAsync(id);
		if (_roleModel != null && _roleModel.Name != null)
			return View(new RoleViewModel
			{
				Id = id,
				RoleName = _roleModel.Name
			});
		else return RedirectToAction("Index");
	}

	[Route("/role/edit/{id}")]
	[HttpPost]
	public async Task<IActionResult> EditAsync(RoleViewModel viewmodel)
	{
		ViewBag.Type = "Edit";
		var _roleModel=await _roleManager.FindByIdAsync(viewmodel.Id);
		if(_roleModel!=null && _roleModel.Name != null)
		{
			await _roleManager.DeleteAsync(_roleModel);
			var result=await _roleManager.CreateAsync(new IdentityRole
			{
				Name = viewmodel.RoleName
			});
			if (result.Succeeded)
			{
				return RedirectToAction("Index");
			}
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError("", error.Description);
			}
		}
		return RedirectToAction("Index");
	}
	[Route("/role/delete/{id}")]
	public async Task<IActionResult> DeleteAsync(string id)
	{
		var _roleModel = await _roleManager.FindByIdAsync(id);
		if (_roleModel != null)
		{
			await _roleManager.DeleteAsync(_roleModel);
		}
		return RedirectToAction("Index");

	}
	[Route("Role/Add")]
	public IActionResult Add()
	{
		ViewBag.Type = "Add";
		return View();
	}

	[HttpPost]
	[Route("Role/Add")]
	public async Task<IActionResult> AddAsync(RoleViewModel viewmodel)
	{
		var _roleModel = await _roleManager.FindByIdAsync(viewmodel.Id);
		if (_roleModel == null)
		{
			ModelState.AddModelError("", "This RoleName is not find");
			var result = await _roleManager.CreateAsync(new IdentityRole
			{
				Name = viewmodel.RoleName
			});
			if (result.Succeeded)
			{
				return RedirectToAction("Index");
			}
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError("", error.Description);
			}
			return View(viewmodel);
		}
		else
		{
			_roleModel.Name = viewmodel.RoleName;
			return View(viewmodel);

		}
	}
}
