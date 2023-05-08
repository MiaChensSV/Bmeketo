using Microsoft.AspNetCore.Mvc;
using WebApp.Helper.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class ProductsController : Controller
{
    private readonly TagService _tagService;

    public ProductsController(TagService tagService)
    {
        _tagService = tagService;
    }

    public async Task<IActionResult> Index()
    {
      
        var viewModel = new ProductsIndexViewModel
        {
            All = new GridCollectionViewModel
            {
                Title = "All Products",
                Categories = new List<string> { "All", "Bags", "laptops" }
            },

			
		};
      
        return View(viewModel);		
	}
	public async Task<IActionResult> Register()
	{

		ViewBag.Tags = await _tagService.GetTagsAsync();
		return View();
	}

	[HttpPost]
    public async Task<IActionResult> Register(ProductRegistrationViewModel viewmodel)
    {
        if (ModelState.IsValid)
        {

        }
        ViewBag.Tags = await _tagService.GetTagsAsync();
        return View(viewmodel);
    }
	

}