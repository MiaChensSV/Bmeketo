using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.CompilerServices;
using Microsoft.Identity.Client;
using WebApp.ViewModels;

namespace WebApp.Models.Entity;

public class ContactFormEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string? CompanyName { get; set; }
    public string Message { get; set; } = null!;
    public DateTime Created { get; set; }=DateTime.Now;
    public bool RememberMe { get; set; } = false;

}
