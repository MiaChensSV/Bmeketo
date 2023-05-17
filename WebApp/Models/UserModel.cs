using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using WebApp.ViewModels.Account;

namespace WebApp.Models;

public class UserModel
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
	public string Roles { get; set; }=null!;

	
}
