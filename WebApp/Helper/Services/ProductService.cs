using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using WebApp.Helper.Repositories;
using WebApp.Models;
using WebApp.Models.Entity;
using WebApp.ViewModels.Admin.Products;

namespace WebApp.Helper.Services;

public class ProductService
{
	private readonly ProductRepository _productRepo;
	private readonly ProductTagRepository _productTagRepo;
	private readonly CategoryService _categoryService;
	private readonly IWebHostEnvironment _webHostEnvironment;
	public ProductService(ProductRepository productRepo, ProductTagRepository productTagRepo, CategoryRepository categoryRepo, CategoryService categoryService, IWebHostEnvironment webHostEnvironment)
	{
		_productRepo = productRepo;
		_productTagRepo = productTagRepo;
		_categoryService = categoryService;
		_webHostEnvironment = webHostEnvironment;
	}
	public async Task<ProductModel> CreateAsync(ProductRegistrationViewModel viewmodel)
	{
		var _productEntity = await _productRepo.GetAsync(x=>x.ArticleNumber== viewmodel.ArticleNumber);
		if (_productEntity == null)
		{
			var _categoryEntity = _categoryService.GetOrCreateCategoryAsync(viewmodel).Result;
			viewmodel.CatagoryId = _categoryEntity.Id.ToString();
			
			_productEntity = await _productRepo.AddAsync(viewmodel);
			return _productEntity;
		}
		else return null!;
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
	public async Task AddProductTagsAsync(ProductRegistrationViewModel viewmodel, string[]tags)
	{
		var _productEntity = await _productRepo.GetAsync(x => x.ArticleNumber == viewmodel.ArticleNumber);
		if(_productEntity != null)
		{
			foreach (var tag in tags)
			{
				await _productTagRepo.AddAsync(new ProductTagEntity
				{
					ArticleNumber = _productEntity.ArticleNumber,
					TagId = int.Parse(tag),
				});
			}
		}

		
	}

	public async Task<bool> UploadImageAsync(ProductModel product,IFormFile imageFile)
	{
		try
		{
			string imagePath = $"{_webHostEnvironment.WebRootPath}/images/products/{product.ImageUrl}";
			await imageFile.CopyToAsync(new FileStream(imagePath,FileMode.Create));
			return true;
		}
		catch { return false; }
		
	}
}
