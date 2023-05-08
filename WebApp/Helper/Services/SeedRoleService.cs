using Microsoft.AspNetCore.Identity;

namespace WebApp.Helper.Services;

public class SeedRoleService
{
	private readonly RoleManager<IdentityRole> _roleManager;

	public SeedRoleService(RoleManager<IdentityRole> roleManager)
	{
		_roleManager = roleManager;
	}
	public async Task SeedRoleAsync()
	{
		if(!await _roleManager.RoleExistsAsync("admin"))
		{
			await _roleManager.CreateAsync(new IdentityRole { Name = "admin" });
		}
		if (!await _roleManager.RoleExistsAsync("user"))
		{
			await _roleManager.CreateAsync(new IdentityRole { Name = "user" });
		}
	}
}
