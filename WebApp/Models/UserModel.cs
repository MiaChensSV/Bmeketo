using Microsoft.AspNetCore.Identity;

namespace WebApp.Models;

public class UserModel
{
	public Guid UserId { get; set; }
	public string FirstName { get; set; } = null!;

	public string LastName { get; set; } = null!;

	public string? CompanyName { get; set; }

	public string? ProfileImageUrl { get; set; }
	public string? StreetName { get; set; }
	public string? PostalCode { get; set; }

	public string? City { get; set; }
	public string Email { get; set; } = null!;
	public string? PhoneNumber { get; set; }
}
