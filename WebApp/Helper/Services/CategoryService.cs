using WebApp.Helper.Repositories;
using WebApp.Models.Entity;
using WebApp.ViewModels;

namespace WebApp.Helper.Services;

public class CategoryService
{
	private readonly CategoryRepository _categoryRepo;

	public CategoryService(CategoryRepository categoryRepo)
	{
		_categoryRepo = categoryRepo;
	}

	public async Task AddProductCategoryAsync(ProductRegistrationViewModel viewmodel)
	{
		var _category = await _categoryRepo.GetAsync(x => x.CategoryName.ToUpper() == viewmodel.CategoryName.ToUpper());
		if (_category == null)
		{
			await _categoryRepo.AddAsync(new CategoryEntity
			{
				CategoryName = viewmodel.CategoryName,
			});
		}

	}
}
