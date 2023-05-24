using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using WebApp.Helper.Repositories;
using WebApp.Models;
using WebApp.Models.Entity;
using WebApp.ViewModels;
using WebApp.ViewModels.Admin.Products;

namespace WebApp.Helper.Services;

public class ProductService
{
	private readonly ProductRepository _productRepo;
	private readonly ProductTagRepository _productTagRepo;
	private readonly CategoryRepository _categoryRepo;
	private readonly CategoryService _categoryService;
	private readonly IWebHostEnvironment _webHostEnvironment;

	public ProductService(ProductRepository productRepo, ProductTagRepository productTagRepo, CategoryRepository categoryRepo, CategoryService categoryService, IWebHostEnvironment webHostEnvironment)
	{
		_productRepo = productRepo;
		_productTagRepo = productTagRepo;
		_categoryRepo = categoryRepo;
		_categoryService = categoryService;
		_webHostEnvironment = webHostEnvironment;
	}

	public async Task<ProductEntity> CreateAsync(ProductRegistrationViewModel viewmodel)
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
	public async Task<List<ProductModel>> GetAllByTagNameAsync(string tagName)
	{
		var _items = await _productRepo.GetAllAsync();
		var _list = new List<ProductModel>();

		foreach (var item in _items)
		{
			var _tagList = new List<string>();
			foreach (var tag in item.Tags)
			{
                _tagList.Add(tag.Tag.TagName);
			}
            _list.Add(new ProductModel
			{
				ArticleNumber = item.ArticleNumber,
				Title = item.Title,
				Description = item.Description,
				CategoryName = item.Category.CategoryName,
				Price = item.Price,
				ImageUrl = item.ImageUrl,
				Tags = _tagList,
			});
		}
		return _list;
	}

	public async Task<ProductModel> GetAsync(string articleNumber)
	{
		ProductEntity _productEntity= await _productRepo.GetAsync(x => x.ArticleNumber == articleNumber);
		if (_productEntity != null)
		{
			var _categoryId = _productEntity.CategoryId;
			var _categoryName = (await _categoryService.GetAsync(_categoryId)).CategoryName;

			return new ProductModel
			{
				ArticleNumber = _productEntity.ArticleNumber,
				Title = _productEntity.Title,
				Description = _productEntity.Description,
				CategoryName = _categoryName,
				Price = _productEntity.Price,
				ImageUrl = _productEntity.ImageUrl,
			};
		}
		else return null!;		
	}
	public async Task<ProductEntity> UpdateAsync(ProductRegistrationViewModel viewmodel )
	{
		var _productEntity= await _productRepo.GetAsync(x => x.ArticleNumber == viewmodel.ArticleNumber);
		var _categoryEntity= await _categoryRepo.GetAsync(x=>x.CategoryName== viewmodel.CategoryName);

		_productEntity.Title = viewmodel.Title;
		_productEntity.Description = viewmodel.Description;
		_productEntity.Price = viewmodel.Price;
		if (viewmodel.ImageFile != null)
		{
			_productEntity.ImageUrl = $"{viewmodel.ArticleNumber}_{viewmodel.ImageFile.FileName}";
		}
		if (_categoryEntity != null)
		{
			_categoryEntity.CategoryName = viewmodel.CategoryName;
			var _newCategroyEntity=await _categoryRepo.UpdateAsync(_categoryEntity);
			
			_productEntity.CategoryId = _newCategroyEntity.Id;

			await _productRepo.UpdateAsync(_productEntity);
		}
		else
		{
			var _newCategroyEntity=await _categoryService.GetOrCreateCategoryAsync(viewmodel);
			_productEntity.CategoryId = _newCategroyEntity.Id;

			await _productRepo.UpdateAsync(_productEntity);
		}
		return _productEntity;



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

	public async Task UpdateProductTagsAsync(ProductRegistrationViewModel viewmodel, string[] tags)
	{
		var _productEntity = await _productRepo.GetAsync(x => x.ArticleNumber == viewmodel.ArticleNumber);
		List<ProductTagEntity> tagsList=(await _productTagRepo.GetAllAsync(x=>x.Product.Id==_productEntity.Id)).ToList();
		if(tagsList.Count >0)
		{
			foreach(var tag in tagsList)
			{
			    _productTagRepo.Delete(tag);
			}
		}
		await AddProductTagsAsync(viewmodel, tags);
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

	public async Task<bool> DeleteAsync(string articleNumber)
	{
		return await _productRepo.DeleteAsync(x=>x.ArticleNumber==articleNumber);		
	}
}
