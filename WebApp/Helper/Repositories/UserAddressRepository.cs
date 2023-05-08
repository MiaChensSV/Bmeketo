using WebApp.Contexts;
using WebApp.Models.Entity;

namespace WebApp.Helper.Repositories
{
	public class UserAddressRepository : Repository<UserAddressEntity>
	{
		public UserAddressRepository(IdentityContext identityContext) : base(identityContext)
		{
		}
	}
}
