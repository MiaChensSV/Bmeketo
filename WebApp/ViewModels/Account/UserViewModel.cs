using System.ComponentModel.DataAnnotations;
using WebApp.Models;
using WebApp.Models.Entity;
using WebApp.Models.Identity;

namespace WebApp.ViewModels.Account;

public class UserViewModel
{
	public string UserId { get; set; } = null!;
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public string? CompanyName { get; set; }
	public string? ProfileImageUrl { get; set; }
	public string? StreetName { get; set; }
	public string? PostalCode { get; set; }

	public string? City { get; set; }
	public string Email { get; set; } = null!;
	public string? PhoneNumber { get; set; }
	public string Roles { get; set; } = null!;

	[Display(Name = "Please type in your current password if you want to change")]
	[DataType(DataType.Password)]
	[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "You Must provide an valid password.")]
	public string? Password { get; set; }

	[Display(Name = "New Password")]
	[DataType(DataType.Password)]
	[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "You Must provide an valid password.")]
	public string NewPassword { get; set; } = null!;

	[Display(Name = "Confirm your Password")]
	[Compare(nameof(NewPassword), ErrorMessage = "Passwords do not match")]
	[DataType(DataType.Password)]
	public string ConfirmNewPassword { get; set; } = null!;
	public string? Role { get; set; }

	public static implicit operator AppIdentityUser(UserViewModel viewmodel)
	{
		var _newUser = new AppIdentityUser
		{
			FirstName=viewmodel.FirstName,
			LastName=viewmodel.LastName,
			Email=viewmodel.Email,
			PhoneNumber=viewmodel.PhoneNumber,
			CompanyName=viewmodel.CompanyName,
			ProfileImageUrl=viewmodel.ProfileImageUrl,
		};
		return _newUser;
	}
	public static implicit operator AddressEntity(UserViewModel viewmodel)
	{
		var _newAddress = new AddressEntity
		{
			StreetName = viewmodel.StreetName,
			PostalCode = viewmodel.PostalCode,
			City = viewmodel.City,
		};
		return _newAddress;
	}
}
