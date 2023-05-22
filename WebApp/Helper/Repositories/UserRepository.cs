using System.Linq.Expressions;
using WebApp.Contexts;
using WebApp.Models.Entity;
using WebApp.Models.Identity;

namespace WebApp.Helper.Repositories;

public class UserRepository : IdentityRepository<AppIdentityUser>
{
	private readonly WebContext _webContext;

	public UserRepository(IdentityContext identityContext, WebContext webContext) : base(identityContext)
	{
		_webContext = webContext;
	}


}
