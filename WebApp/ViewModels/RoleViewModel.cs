using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels;

public class RoleViewModel
{
	public string Id { get; set; } = null!;
	[Required]
	[Display(Name ="Role")]
	public string RoleName { get; set; } 
}
