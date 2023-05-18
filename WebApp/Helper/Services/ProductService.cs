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
		ProductModel _productModel = await _productRepo.GetAsync(x=>x.ArticleNumber== viewmodel.ArticleNumber);
		if (_productModel == null)
		{
			var _categoryEntity = _categoryService.GetOrCreateCategoryAsync(viewmodel).Result;
			viewmodel.CatagoryId = _categoryEntity.Id.ToString();
			
			_productModel = await _productRepo.AddAsync(viewmodel);
			return _productModel;
		}
		else return null!;
	}

	public async Task<IEnumerable<ProductEntity>> GetAllAsync()
	{
		return await _productRepo.GetAllAsync();
	}
	public async Task<List<ProductModel>> GetAllByTagNameAsync(string tagName)
	{
		var items = await _productRepo.GetAllAsync();
		var list = new List<ProductModel>();

		foreach (var item in items)
		{
			var tagList = new List<string>();
			foreach (var tag in item.Tags)
			{
				tagList.Add(tag.Tag.TagName);
			}
			list.Add(new ProductModel
			{
				ArticleNumber = item.ArticleNumber,
				Title = item.Title,
				Description = item.Description,
				CategoryName = item.Category.CategoryName,
				Price = item.Price,
				ImageUrl = item.ImageUrl,
				Tags = tagList,
			});
		}
		return list;
	}

	public async Task<ProductModel> GetAsync(string articleNumber)
	{
		ProductEntity productEntity= await _productRepo.GetAsync(x => x.ArticleNumber == articleNumber);
		var categoryId= productEntity.CategoryId;
		var categoryName= (await _categoryService.GetAsync(categoryId)).CategoryName;

		return new ProductModel
		{
			ArticleNumber = productEntity.ArticleNumber,
			Title = productEntity.Title,
			Description = productEntity.Description,
			CategoryName = categoryName,
			Price = productEntity.Price,
			ImageUrl = productEntity.ImageUrl,
		};
	}
	public async Task<ProductModel> UpdateAsync(ProductRegistrationViewModel viewmodel )
	{
		ProductModel _productModel= await _productRepo.GetAsync(x => x.ArticleNumber == viewmodel.ArticleNumber);
		if (_productModel != null)
		{
			
			_productModel.Title= viewmodel.Title;
		
			_productModel.Description = viewmodel.Description;
			
			_productModel.Price = viewmodel.Price;
			
			_productModel.CategoryName = viewmodel.CategoryName;
			await _categoryService.GetOrCreateCategoryAsync(viewmodel);
			

			_productModel = await _productRepo.UpdateAsync(_productModel);

			return _productModel;
		}return null!;
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

	public async Task<bool> DeleteAsync(string articleNumber)
	{
		return await _productRepo.DeleteAsync(x=>x.ArticleNumber==articleNumber);		
	}

}
