using Microsoft.AspNetCore.Mvc;
using WebApp.Helper.Services;
using WebApp.Models.Entity;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly CategoryService _categoryService;
    private readonly HomeService _homeService;

    public HomeController(CategoryService categoryService, HomeService homeService)
    {
        _categoryService = categoryService;
        _homeService = homeService;
    }

    public async Task<IActionResult> IndexAsync()
	{
		var categoryNameList = new List<string>();
		_categoryService.GetAllAsync().Result.ToList<CategoryEntity>().ForEach(el => categoryNameList.Add(el.CategoryName));

        var viewModel = new HomeViewModel
		{
			Title = "Home",
			BestCollection = new GridCollectionViewModel
			{
				Title = "Best Collection",
				Categories = categoryNameList,
				GridItems = _homeService.GetBestCollectionList(),
				LoadMore = false,
			},
            UpToSellItem = new GridCollectionViewModel
            {
                GridItems =_homeService.GetUpToSellList(),
            },
            TopSellingCollection =new GridCollectionViewModel
			{
				Title="Top selling products in this week",
				GridItems=await _homeService.GetTopItemListAsync(),
            },
        };
		return View(viewModel);
	}
}
