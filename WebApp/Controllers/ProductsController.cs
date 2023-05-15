using Microsoft.AspNetCore.Mvc;
using WebApp.Helper.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class ProductsController : Controller
{

	private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    public IActionResult Index()
	{
		return View();
	}

	public async Task<IActionResult> Details(string articleNumber)
	{
		var _product = await _productService.GetAsync(articleNumber);
		return View(_product);
	}

}