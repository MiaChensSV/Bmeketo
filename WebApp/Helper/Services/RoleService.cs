using System.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Models.Entity;

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
		var roles = new List<SelectListItem>();
		foreach (var role in await _roleManager.Roles.ToListAsync())
		{
			roles.Add(new SelectListItem
			{
				Value = role.Id.ToString(),
				Text = role.Name,
				Selected = false
			});
		}
		return roles;
	}

	public async Task<List<SelectListItem>> GetSpecificRoleAsync(string selectedTags)
	{
		var roles = new List<SelectListItem>();
		foreach (var role in await _roleManager.Roles.ToListAsync())
		{
			roles.Add(new SelectListItem
			{
				Value = role.Id.ToString(),
				Text = role.Name,
				Selected= selectedTags.Contains(role.Id.ToString()),
			});
		}
		return roles;
	}

	

}
