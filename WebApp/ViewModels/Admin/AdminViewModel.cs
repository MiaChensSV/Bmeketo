using WebApp.Models.Entity;
using WebApp.Models.Identity;

namespace WebApp.ViewModels.Admin;

public class AdminViewModel
{
	public IList<AppIdentityUser> Users { get; set; } = new List<AppIdentityUser>();
	public IList<ContactFormEntity> ContactIssues { get; set; }=new List<ContactFormEntity>();
}
