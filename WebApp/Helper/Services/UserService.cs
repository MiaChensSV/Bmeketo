﻿using System;
using Microsoft.AspNetCore.Hosting;
using WebApp.Helper.Repositories;
using WebApp.Models;
using WebApp.Models.Entity;
using WebApp.Models.Identity;
using WebApp.ViewModels.Account;

namespace WebApp.Helper.Services;

public class UserService
{
	private readonly UserRepository _userRepo;
	private readonly AddressRepository _addressRepo;
	private readonly IWebHostEnvironment _webHostEnvironment;

	public UserService(UserRepository userRepo, IWebHostEnvironment webHostEnvironment, AddressRepository addressRepo)
	{
		_userRepo = userRepo;
		_webHostEnvironment = webHostEnvironment;
		_addressRepo = addressRepo;
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
		return await _userRepo.GetAsync(x=>x.Id==id);
	}
	public async Task UpdateAsync(UserViewModel viewmodel)
	{
		await _userRepo.UpdateAsync(viewmodel);
		await _addressRepo.UpdateAsync(viewmodel);
	}
}
