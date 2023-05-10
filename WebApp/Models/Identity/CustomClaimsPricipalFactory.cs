using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace WebApp.Models.Identity;

public class CustomClaimsPricipalFactory : UserClaimsPrincipalFactory<AppIdentityUser>
{
	private readonly UserManager<AppIdentityUser> userManager;

	public CustomClaimsPricipalFactory(UserManager<AppIdentityUser> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
	{
		this.userManager = userManager;
	}

	protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppIdentityUser user)
	{
		var claimsIdentity=await base.GenerateClaimsAsync(user);
		claimsIdentity.AddClaim(new Claim("DisplayName", $"{user.FirstName} {user.LastName}"));
		var roles = await UserManager.GetRolesAsync(user);

		claimsIdentity.AddClaims(roles.Select(x => new Claim(ClaimTypes.Role, x)));
		return claimsIdentity;
	}
}
