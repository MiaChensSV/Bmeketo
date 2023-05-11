﻿using WebApp.Contexts;
using WebApp.Helper.Repositories;
using WebApp.Models.Entity;
using WebApp.Models.Identity;
using WebApp.ViewModels;

namespace WebApp.Services;

public class AddressService
{
	private readonly AddressRepository _addressRepo;
	private readonly UserAddressRepository _userAddressRepo;

	public AddressService(AddressRepository addressRepo, UserAddressRepository userAddressRepo)
	{
		_addressRepo = addressRepo;
		_userAddressRepo = userAddressRepo;
	}

	public async Task<AddressEntity> GetOrCreateAsync(AddressEntity addressEntity)
	{
		var entity=await _addressRepo.GetAsync(x=>
			x.StreetName == addressEntity.StreetName && 
			x.PostalCode == addressEntity.PostalCode && 
			x.City == addressEntity.City
			);
		if(entity == null) 
		{
			if (addressEntity.City!=null || addressEntity.StreetName!= null || addressEntity.PostalCode != null)
			{
				var newAdressEntity = await _addressRepo.AddAsync(addressEntity);
				return newAdressEntity;
			}
			else return null!;


		}else return entity;
	}

	public async Task AddAdressAsync(AppIdentityUser appUser, AddressEntity addressEntity)
	{
		await _userAddressRepo.AddAsync(new UserAddressEntity
		{
			UserId= appUser.Id,
			AddressId=addressEntity.Id
		});
	}
}
