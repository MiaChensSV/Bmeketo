using Microsoft.AspNetCore.Identity;
using WebApp.Models.Identity;

namespace WebApp.ViewModels.Admin.Users;

public class AdminUsersViewModel
{
    public IList<AppIdentityUser> Users { get; set; }=new List<AppIdentityUser>();
    public IList<AppIdentityUser> Admins { get; set; } = new List<AppIdentityUser>();
    public IList<IdentityRole> Roles { get; set; }
}
