using Microsoft.AspNetCore.Mvc;
using WebApp.Helper.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class ProductsController : Controller
{
    private readonly TagService _tagService;
    private readonly ProductService _productService;
    private readonly CategoryService _categoryService;

	public ProductsController(TagService tagService, ProductService productService, CategoryService categoryService)
	{
		_tagService = tagService;
		_productService = productService;
		_categoryService = categoryService;
	}

	public IActionResult Index()
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
    public async Task<IActionResult> Register(ProductRegistrationViewModel viewmodel, string[]tags)
    {
        if (ModelState.IsValid)
        {
            var result= await _productService.CreateAsync(viewmodel);
            if (result)
            {
				await _productService.AddProductTagsAsync(viewmodel, tags);
				await _categoryService.AddProductCategoryAsync(viewmodel);
				return RedirectToAction("Index","Products");
			}
            ModelState.AddModelError("", "Something went wrong");

		}
        ViewBag.Tags = await _tagService.GetTagsAsync(tags);
        return RedirectToAction("Register","Products");
    }
	

}