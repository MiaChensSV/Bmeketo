using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Helper.Services;
public class RoleService
{
	private readonly RoleManager<IdentityRole> _roleManager;

	public RoleService(RoleManager<IdentityRole> roleManager)
	{
		_roleManager = roleManager;
	}

	public async Task<List<SelectListItem>> GetRolesAsync()
	{
		var _roles = new List<SelectListItem>();
		foreach (var role in await _roleManager.Roles.ToListAsync())
		{
            _roles.Add(new SelectListItem
			{
				Value = role.Id.ToString(),
				Text = role.Name,
				Selected = false
			});
		}
		return _roles;
	}
}
