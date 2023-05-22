using Microsoft.AspNetCore.Identity;
using WebApp.Helper.Repositories;
using WebApp.Models;
using WebApp.Models.Entity;
using WebApp.Models.Identity;
using WebApp.Services;
using WebApp.ViewModels.Account;

namespace WebApp.Helper.Services;

public class UserService
{
	private readonly UserRepository _userRepo;
	private readonly AddressRepository _addressRepo;
	private readonly UserAddressRepository _userAddressRepo;
	private readonly UserManager<AppIdentityUser> _userManager;
	private readonly RoleManager<IdentityRole> _roleManager;
	private readonly AddressService _addressService;
	private readonly RoleService _roleService;
	private readonly IWebHostEnvironment _webHostEnvironment;

	public UserService(UserRepository userRepo, IWebHostEnvironment webHostEnvironment, AddressRepository addressRepo, UserAddressRepository userAddressRepo, UserManager<AppIdentityUser> userManager, AddressService addressService, RoleManager<IdentityRole> roleManager, RoleService roleService)
	{
		_userRepo = userRepo;
		_webHostEnvironment = webHostEnvironment;
		_addressRepo = addressRepo;
		_userAddressRepo = userAddressRepo;
		_userManager = userManager;
		_addressService = addressService;
		_roleManager = roleManager;
		_roleService = roleService;
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
	public async Task<UserModel> GetAsync(string id)
	{
		AppIdentityUser _appUser=await _userRepo.GetAsync(x=>x.Id==id);
		UserAddressEntity _userAddressEntity = await _userAddressRepo.GetAsync(x => x.UserId == id);
		if (_userAddressEntity!= null)
		{
			AddressEntity _addressEntity = await _addressRepo.GetAsync(x => x.Id == _userAddressEntity.AddressId);
			return new UserModel
			{
				FirstName = _appUser.FirstName,
				LastName = _appUser.LastName,
				CompanyName = _appUser.CompanyName,
				ProfileImageUrl = _appUser.ProfileImageUrl,
				StreetName = _addressEntity.StreetName,
				PostalCode = _addressEntity.PostalCode,
				City = _addressEntity.City,
				Email = _appUser.Email!,
				PhoneNumber = _appUser.PhoneNumber,
			};
		}
		else return new UserModel
		{
			FirstName = _appUser.FirstName,
			LastName = _appUser.LastName,
			CompanyName = _appUser.CompanyName,
			ProfileImageUrl = _appUser.ProfileImageUrl,
			Email = _appUser.Email!,
			PhoneNumber = _appUser.PhoneNumber,
		};
	}

	public async Task<UserModel> GetByEmailAsync(string email)
	{
		AppIdentityUser _appUser = await _userRepo.GetAsync(x => x.Email == email);
		UserAddressEntity _userAddressEntity = await _userAddressRepo.GetAsync(x => x.UserId == _appUser.Id);
		if (_userAddressEntity != null)
		{
			AddressEntity _addressEntity = await _addressRepo.GetAsync(x => x.Id == _userAddressEntity.AddressId);
			return new UserModel
			{
				FirstName = _appUser.FirstName,
				LastName = _appUser.LastName,
				CompanyName = _appUser.CompanyName,
				ProfileImageUrl = _appUser.ProfileImageUrl,
				StreetName = _addressEntity.StreetName,
				PostalCode = _addressEntity.PostalCode,
				City = _addressEntity.City,
				Email = _appUser.Email!,
				PhoneNumber = _appUser.PhoneNumber,
			};
		}
		else return new UserModel
		{
			FirstName = _appUser.FirstName,
			LastName = _appUser.LastName,
			CompanyName = _appUser.CompanyName,
			ProfileImageUrl = _appUser.ProfileImageUrl,
			Email = _appUser.Email!,
			PhoneNumber = _appUser.PhoneNumber,
		};
	}
	

	public async Task UpdateAsync(UserViewModel viewmodel)
	{
		var _appUser =  await _userRepo.GetAsync(x => x.Email == viewmodel.Email);
		_appUser.FirstName = viewmodel.FirstName;
		_appUser.LastName = viewmodel.LastName;
		_appUser.CompanyName = viewmodel.CompanyName;
		_appUser.PhoneNumber = viewmodel.PhoneNumber;
		await _userRepo.UpdateAsync(_appUser);

		await _userManager.AddToRoleAsync(_appUser, viewmodel.Role!);

		var userAddressEntity = await _userAddressRepo.GetAsync(x => x.UserId == _appUser.Id);
		if (userAddressEntity == null)
		{
			var _adressEntity = new AddressEntity
			{
				StreetName = viewmodel.StreetName,
				City = viewmodel.City,
				PostalCode = viewmodel.PostalCode,
			};
			await _addressRepo.AddAsync(_adressEntity);
			userAddressEntity = new UserAddressEntity { UserId= _appUser.Id,AddressId= _adressEntity.Id };
			await _userAddressRepo.AddAsync(userAddressEntity);		
		}
		else
		{
			var _adressEntity = await _addressRepo.GetAsync(x => x.Id == userAddressEntity.AddressId);
			_adressEntity.StreetName = viewmodel.StreetName;
			_adressEntity.City = viewmodel.City;
			_adressEntity.PostalCode = viewmodel.PostalCode;
			await _addressRepo.UpdateAsync(_adressEntity);
		}		
	}

	public async Task<UserModel> CreateUserAsync(RegistrationViewModel viewmodel)
	{
		AppIdentityUser appUser = viewmodel;
		var result = await _userManager.CreateAsync(appUser, viewmodel.Password);
		if (result.Succeeded)
		{
			await _userManager.AddToRoleAsync(appUser, viewmodel.Role);
			var addressEntity = await _addressService.GetOrCreateAsync(viewmodel);
			if (addressEntity != null)
			{
				await _addressService.AddAdressAsync(appUser, addressEntity);
			}
			return new UserModel
			{
				FirstName = viewmodel.FirstName,
				LastName = viewmodel.LastName,
				CompanyName = viewmodel.CompanyName,
				StreetName= viewmodel.StreetName,
				City= viewmodel.City,
				PostalCode= viewmodel.PostalCode,
				Role= viewmodel.Role,
				Email= viewmodel.Email,
				PhoneNumber= viewmodel.PhoneNumber,
			};
		}
		return null!;
	}


}
