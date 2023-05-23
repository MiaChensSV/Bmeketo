using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Models.Identity;
using WebApp.Services;
using WebApp.ViewModels.Account;

namespace WebApp.Helper.Services;

public class AuthService
{
    private readonly UserManager<AppIdentityUser> _userManager;
    private readonly SignInManager<AppIdentityUser> _signInManager;
    private readonly AddressService _addressService;
    private readonly SeedRoleService _seeds;

	public AuthService(UserManager<AppIdentityUser> userManager, AddressService addressService, SignInManager<AppIdentityUser> signInManager, SeedRoleService seeds)
	{
		_userManager = userManager;
		_addressService = addressService;
		_signInManager = signInManager;
		_seeds = seeds;
	}

	public async Task<bool> UserExistAsync(Expression<Func<AppIdentityUser, bool>> expression)
	{
		var _result = await _userManager.Users.AnyAsync(expression);
		return _result;
	}

	public async Task<UserModel> RegisterUserAsync(RegistrationViewModel viewmodel)
    {
        await _seeds.SeedRoleAsync();
        var _standardRole = "user";
        if(!await _userManager.Users.AnyAsync())
        {
			_standardRole = "admin";
        }
        AppIdentityUser appUser = viewmodel;
        var _result = await _userManager.CreateAsync(appUser, viewmodel.Password);
        if (_result.Succeeded)
        {
			await _userManager.AddToRoleAsync(appUser, _standardRole);
			var _addressEntity =await _addressService.GetOrCreateAsync(viewmodel);
            if (_addressEntity != null)
            {
                await _addressService.AddAdressAsync(appUser, _addressEntity);
			}            
			return appUser;

		}
		return null!;    
    }   

    public async Task<bool> LoginAsync(LoginViewModel viewmodel)
    {
        var _appUser=await _userManager.Users.FirstOrDefaultAsync(x=>x.Email== viewmodel.Email);
        if(_appUser != null)
        {
            var result=await _signInManager.PasswordSignInAsync(_appUser, viewmodel.Password,viewmodel.RememberMe,false);
            return result.Succeeded;
        }
        return false;
	}
}
