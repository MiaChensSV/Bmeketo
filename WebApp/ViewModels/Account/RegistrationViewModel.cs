using System.ComponentModel.DataAnnotations;
using WebApp.Models;
using WebApp.Models.Entity;
using WebApp.Models.Identity;

namespace WebApp.ViewModels.Account;

public class RegistrationViewModel
{
    [Display(Name = "First Name")]
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "Last Name is required")]
    public string LastName { get; set; } = null!;

    [Display(Name = "Email Address")]
    [Required(ErrorMessage = "Email Address is required")]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "You Must provide an valid email address.")]
    public string Email { get; set; } = null!;

    [Display(Name = "Phone Number(options)")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Company Name(options)")]
    public string? CompanyName { get; set; }

    [Display(Name = "Password")]
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "You Must provide an valid password.")]
    public string Password { get; set; } = null!;

    [Display(Name = "Confirm your Password")]
    [Required(ErrorMessage = "Confirm password is required")]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = null!;

    [Display(Name = "Street Name(options)")]
    public string? StreetName { get; set; }

    [Display(Name = "Postal Code(options)")]
    public string? PostalCode { get; set; }

    [Display(Name = "City(options)")]
    public string? City { get; set; }

    [Display(Name = "Upload Profile Image(options)")]
    [DataType(DataType.Upload)]
    public IFormFile? ImageFile { get; set; }

    [Display(Name = "I have read and accept the terms and agreements")]
    [Required(ErrorMessage = "You must read and accept the terms and agreements")]
    public bool TermsAndAgreement { get; set; } = false;
	public string Role { get; set; }=null!;

	public static implicit operator AppIdentityUser(RegistrationViewModel viewModel)
    {
        var _newUser= new AppIdentityUser
        {
            UserName = viewModel.Email,
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
            Email = viewModel.Email,
            PhoneNumber = viewModel.PhoneNumber,
            
        };
        if(viewModel.ImageFile!= null )
        {
            _newUser.ProfileImageUrl = $"{viewModel.FirstName}_{viewModel.LastName}_{viewModel.ImageFile.FileName}";
        }
        return _newUser;
    }
    public static implicit operator AddressEntity(RegistrationViewModel viewModel)
    {
        return new AddressEntity
        {
            StreetName = viewModel.StreetName,
            PostalCode = viewModel.PostalCode,
            City = viewModel.City,
        };
    }
    public static implicit operator UserModel(RegistrationViewModel viewModel)
    {
        return new UserModel
        {
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
            Email = viewModel.Email,
            PhoneNumber = viewModel.PhoneNumber,
            StreetName = viewModel.StreetName,
            PostalCode = viewModel.PostalCode,
            City = viewModel.City,
            Role = viewModel.Role,
        };
    }
}
