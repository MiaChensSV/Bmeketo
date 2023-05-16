
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApp.Helper.Services;
using WebApp.Models;
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

	public async Task<IActionResult> IndexAsync()
	{
		var categoryNameList = new List<string>();
		_categoryService.GetAllAsync().Result.ToList<CategoryEntity>().ForEach(el => categoryNameList.Add(el.CategoryName));

		var gridList = new List<GridCollectionItemViewModel>();
		var _griditemslist = _productService.GetAllAsync().Result.ToList<ProductEntity>();
		
		//get gridcollectionitems for maximum 8 or the length of the list
		for (int i = 0; i < Math.Min(_griditemslist.Count, 8); i++)
		{
			gridList.Add(new GridCollectionItemViewModel
			{
				Id = _griditemslist[i].ArticleNumber,
				ImageUrl = _griditemslist[i].ImageUrl,
				Title = _griditemslist[i].Title,
				Price = _griditemslist[i].Price,
			});
		};

		//get radom product in uptoSell
        Random r = new Random();
        int uptoSellRandomNr1 =r.Next(0, _griditemslist.Count);

        GridCollectionItemViewModel upToSellItem1 = new ()
		{
            Id = _griditemslist[uptoSellRandomNr1].ArticleNumber,
            ImageUrl = _griditemslist[uptoSellRandomNr1].ImageUrl,
            Title = _griditemslist[uptoSellRandomNr1].Title,
            Price = _griditemslist[uptoSellRandomNr1].Price,
        };

        int uptoSellRandomNr2 = r.Next(0, _griditemslist.Count);
        GridCollectionItemViewModel upToSellItem2 = new()
        {
            Id = _griditemslist[uptoSellRandomNr2].ArticleNumber,
            ImageUrl = _griditemslist[uptoSellRandomNr2].ImageUrl,
            Title = _griditemslist[uptoSellRandomNr2].Title,
            Price = _griditemslist[uptoSellRandomNr2].Price,
        };

		var topSellingList= new List<GridCollectionItemViewModel>();
        var _topitemslist =await _productService.GetAllByTagNameAsync("Popular");

        for (int i = 0; i < Math.Min(_topitemslist.Count, 7); i++)
        {
            topSellingList.Add(new GridCollectionItemViewModel
            {
                Id = _topitemslist[i].ArticleNumber,
                ImageUrl = _topitemslist[i].ImageUrl,
                Title = _topitemslist[i].Title,
                Price = _topitemslist[i].Price,
            });
        };

        var viewModel = new HomeViewModel
		{
			Title = "Home",
			BestCollection = new GridCollectionViewModel
			{
				Title = "Best Collection",
				Categories = categoryNameList,
				GridItems = gridList,
				LoadMore = false,
			},
			UpToSellItem1=upToSellItem1,
			UpToSellItem2=upToSellItem2,
			TopSellingCollection =new GridCollectionViewModel
			{
				Title="Top selling products in this week",
				GridItems=topSellingList,
            },
        };
		return View(viewModel);
	}
}
