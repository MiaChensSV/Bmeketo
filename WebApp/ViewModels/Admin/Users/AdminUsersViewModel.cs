using Microsoft.AspNetCore.Identity;

namespace WebApp.ViewModels.Admin.Users;

public class AdminUsersViewModel
{
    public List<IdentityUser> Users { get; set; }=new List<IdentityUser>();
    public ICollection<IdentityUser> Admins { get; set; } = new List<IdentityUser>();
}
