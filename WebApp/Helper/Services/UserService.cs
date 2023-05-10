using WebApp.Helper.Repositories;
using WebApp.Models.Entity;
using WebApp.Models.Identity;

namespace WebApp.Helper.Services;

public class UserService
{
	private readonly UserRepository _userRepo;

	public UserService(UserRepository userRepo)
	{
		_userRepo = userRepo;
	}

	public async Task<IEnumerable<AppIdentityUser>> GetAllAsync()
	{
		return await _userRepo.GetAllAsync();
	}

}
