using WebApp.Helper.Repositories;
using WebApp.Models.Entity;
using WebApp.ViewModels.Admin.Products;

namespace WebApp.Helper.Services;

public class CategoryService
{
	private readonly CategoryRepository _categoryRepo;
	private readonly ProductRepository _productRepo;

	public CategoryService(CategoryRepository categoryRepo, ProductRepository productRepo)
	{
		_categoryRepo = categoryRepo;
		_productRepo = productRepo;
	}




	public async Task<CategoryEntity> GetOrCreateCategoryAsync(ProductRegistrationViewModel viewmodel)
	{
		var _categoryEntity = await _categoryRepo.GetAsync(x => x.CategoryName.ToUpper() == viewmodel.CategoryName.ToUpper());
		if(_categoryEntity == null )
		{
			_categoryEntity = await _categoryRepo.AddAsync(new CategoryEntity
							{
								CategoryName = viewmodel.CategoryName,
							}) ;

		}
		return _categoryEntity!;
	}

	public async Task<IEnumerable<CategoryEntity>> GetAllAsync()
	{
		return await _categoryRepo.GetAllAsync();
	}
	public async Task<CategoryEntity> GetAsync(Guid categoryId)
	{
		return await _categoryRepo.GetAsync(x=>x.Id==categoryId);
	}
	public async Task<CategoryEntity> GetProductCategoryAsync(string articleNumber)
	{
		var _productEntity=await _productRepo.GetAsync(x=>x.ArticleNumber==articleNumber);
		return await _categoryRepo.GetAsync(x => x.Id == _productEntity.CategoryId);
	}
}
