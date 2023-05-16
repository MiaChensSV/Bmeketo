using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApp.Helper.Services;
using WebApp.Models.Entity;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class ProductsController : Controller
{

	private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
	{
		var _gridProductsList = _productService.GetAllAsync().Result.ToList<ProductEntity>();
		var _productsList = new List<GridCollectionItemViewModel>();
		for (int i = 0; i < (_gridProductsList.Count); i++)
		{
			_productsList.Add(new GridCollectionItemViewModel
			{
				Id = _gridProductsList[i].ArticleNumber,
				ImageUrl = _gridProductsList[i].ImageUrl,
				Title = _gridProductsList[i].Title,
				Price = _gridProductsList[i].Price,
			});
		};
		var viewmodel = new ProductsIndexViewModel
		{
			Title = "All Products",
			All = new GridCollectionViewModel 
			{
				GridItems= _productsList,
			}
		};
		return View(viewmodel);
	}

	public async Task<IActionResult> Details(string articleNumber)
	{
		var _product = await _productService.GetAsync(articleNumber);
		return View(_product);
	}

}