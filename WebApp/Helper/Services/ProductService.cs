using WebApp.Helper.Repositories;
using WebApp.Models.Entity;
using WebApp.ViewModels;

namespace WebApp.Helper.Services;

public class ProductService
{
	private readonly ProductRepository _productRepo;
	private readonly ProductTagRepository _productTagRepo;

	public ProductService(ProductRepository productRepo, ProductTagRepository productTagRepo, CategoryRepository categoryRepo)
	{
		_productRepo = productRepo;
		_productTagRepo = productTagRepo;
	}
	public async Task<bool> CreateAsync(ProductEntity entity)
	{
		var _entity = await _productRepo.GetAsync(x=>x.Id==entity.Id);
		if (_entity == null)
		{
			_entity=await _productRepo.AddAsync(entity);
			if(_entity!=null)
				return true;
		}
		return false;
	}

	public async Task<IEnumerable<ProductEntity>> GetAllAsync()
	{
		return await _productRepo.GetAllAsync();
	}

	public async Task<ProductEntity> GetAsync(Guid id)
	{
		return await _productRepo.GetAsync(x=>x.Id==id);
	}
	public async Task<bool> UpdateAsync(ProductEntity entity)
	{
		var _productEntity= await _productRepo.GetAsync(x => x.Id == entity.Id);
		if (_productEntity != null)
		{
			if(string.IsNullOrEmpty(_productEntity.Title))
			{
				_productEntity.Title=entity.Title;
			};
			if (string.IsNullOrEmpty(_productEntity.Description))
			{
				_productEntity.Description = entity.Description;
			};
			_productEntity.Price = entity.Price;
			if (string.IsNullOrEmpty(_productEntity.ImageUrl))
			{
				_productEntity.ImageUrl = entity.ImageUrl;
			};
			return true;
		}return false;
	}
	public async Task AddProductTagsAsync(ProductEntity entity, string[]tags)
	{
		foreach (var tag in tags)
		{
			await _productTagRepo.AddAsync(new ProductTagEntity
			{
				ProductId = entity.Id,
				TagId=int.Parse(tag),
			});
		}
	}
	
}
