using WebApp.Contexts;
using WebApp.Models.Identity;

namespace WebApp.Helper.Repositories
{
	public class UserRepository : IdentityRepository<AppIdentityUser>
	{
		public UserRepository(IdentityContext identityContext) : base(identityContext)
		{
		}
	}
}
