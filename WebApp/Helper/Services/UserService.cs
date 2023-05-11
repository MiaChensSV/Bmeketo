using Microsoft.AspNetCore.Hosting;
using WebApp.Helper.Repositories;
using WebApp.Models;
using WebApp.Models.Entity;
using WebApp.Models.Identity;

namespace WebApp.Helper.Services;

public class UserService
{
	private readonly UserRepository _userRepo;
	private readonly IWebHostEnvironment _webHostEnvironment;

	public UserService(UserRepository userRepo, IWebHostEnvironment webHostEnvironment)
	{
		_userRepo = userRepo;
		_webHostEnvironment = webHostEnvironment;
	}

	public async Task<IEnumerable<AppIdentityUser>> GetAllAsync()
	{
		return await _userRepo.GetAllAsync();
	}

	public async Task<bool> UploadImageAsync(UserModel user, IFormFile imageFile)
	{
		try
		{
			string imagePath = $"{_webHostEnvironment.WebRootPath}/images/users/{user.ProfileImageUrl}";
			await imageFile.CopyToAsync(new FileStream(imagePath, FileMode.Create));
			return true;
		}
		catch { return false; }
	}
}
