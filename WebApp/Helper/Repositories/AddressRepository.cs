using WebApp.Contexts;
using WebApp.Models.Entity;

namespace WebApp.Helper.Repositories;

public class AddressRepository : Repository<AddressEntity>
{
public AddressRepository(IdentityContext identityContext) : base(identityContext)
	{
	}
}
