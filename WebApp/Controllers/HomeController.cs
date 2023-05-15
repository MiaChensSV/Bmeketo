
using Microsoft.AspNetCore.Mvc;
using WebApp.Helper.Services;
using WebApp.Models.Entity;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ProductService _productService;
    private readonly CategoryService _categoryService;

    public HomeController(ProductService productService, CategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

	public IActionResult Index()
	{
		var categoryNameList = new List<string>();
		_categoryService.GetAllAsync().Result.ToList<CategoryEntity>().ForEach(el => categoryNameList.Add(el.CategoryName));

		var gridList = new List<GridCollectionItemViewModel>();
		_productService.GetAllAsync().Result.ToList<ProductEntity>().ForEach(entity =>
		{
			gridList.Add(new GridCollectionItemViewModel
			{
				Id = entity.ArticleNumber,
				ImageUrl = entity.ImageUrl,
				Title = entity.Title,
				Price = entity.Price,
			});
		});

		var viewModel = new HomeViewModel
		{
			Title = "Home",
			BestCollection = new GridCollectionViewModel
			{
				Categories = categoryNameList,

				GridItems = gridList,
				LoadMore = false,
			}
		};
		return View(viewModel);
	}
}
