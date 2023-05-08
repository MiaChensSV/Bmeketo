using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Models.Identity;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Helper.Services;

public class AuthService
{
    private readonly UserManager<AppIdentityUser> _userManager;
    private readonly AddressService _addressService;

    public AuthService(UserManager<AppIdentityUser> userManager, AddressService addressService)
    {
        _userManager = userManager;
        _addressService = addressService;
    }

	public async Task<bool> UserExistAsync(Expression<Func<AppIdentityUser, bool>> expression)
	{
		var result = await _userManager.Users.AnyAsync(expression);
		return result;
	}

	public async Task<bool> RegisterUserAsync(RegistrationViewModel viewmodel)
    {
        AppIdentityUser appUser = viewmodel;
        var result = await _userManager.CreateAsync(appUser, viewmodel.Password);
        if (result.Succeeded)
        {
            var addressEntity =await _addressService.GetOrCreateAsync(viewmodel);
            if (addressEntity != null)
            {
                await _addressService.AddAdressAsync(appUser, addressEntity);
                return true;
            }
        }
        return false;
    
    }   
}
