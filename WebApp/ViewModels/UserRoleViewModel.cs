using WebApp.Models.Identity;

namespace WebApp.ViewModels;

public class UserRoleViewModel
{
	public UserRoleViewModel(string roleId, string userId, List<AppIdentityUser> users)
	{
		RoleId = roleId;
		UserId = userId;
		Users = users;
	}

	public string RoleId { get; set; }
	public string UserId { get; set; }

	public List<AppIdentityUser> Users { get; set; }
}
