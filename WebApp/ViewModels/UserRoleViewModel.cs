using WebApp.Models.Identity;

namespace WebApp.ViewModels;

public class UserRoleViewModel
{
	public string RoleId { get; set; }
	public string UserId { get; set; }

	public List<AppIdentityUser> Users { get; set; }
}
