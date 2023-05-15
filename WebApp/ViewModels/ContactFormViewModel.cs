using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using WebApp.Models.Entity;

namespace WebApp.ViewModels;

public class ContactFormViewModel
{
    [Display(Name = "Your Name*")]
    [Required(ErrorMessage = "Your name is required")]
    public string Name { get; set; } = null!;

    [Display(Name = "Your Email*")]
    [Required(ErrorMessage = "Email Address is required")]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "You Must provide an valid email address.")]
    public string Email { get; set; }=null!;

    [Display(Name = "Phone Number")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Company Name(options)")]
    public string? CompanyName { get; set; }

    [Display(Name = "Something write*")]
    public string Message { get; set; }= null!;

    [Display(Name = "Save my name, email in the this browser for the next time I comment.")]
	public bool RememberMe { get; set; } = false;

    public static implicit operator ContactFormEntity(ContactFormViewModel model)
    {
        var _contactFormEntity = new ContactFormEntity
        {
            Name = model.Name,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            CompanyName = model.CompanyName,
            Message = model.Message,
            RememberMe = model.RememberMe
        };
        return  _contactFormEntity;
    }

}
