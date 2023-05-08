using WebApp.Contexts;
using WebApp.Models.Entity;

namespace WebApp.Helper.Repositories;

public class UserAddressRepository : IdentityRepository<UserAddressEntity>
{
	public UserAddressRepository(IdentityContext identityContext) : base(identityContext)
	{
	}
}
