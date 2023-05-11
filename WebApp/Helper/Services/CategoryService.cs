using WebApp.Helper.Repositories;
using WebApp.Models.Entity;
using WebApp.ViewModels.Admin.Products;

namespace WebApp.Helper.Services;

public class CategoryService
{
	private readonly CategoryRepository _categoryRepo;

	public CategoryService(CategoryRepository categoryRepo)
	{
		_categoryRepo = categoryRepo;
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

}
