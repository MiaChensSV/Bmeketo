using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Helper.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;
[Authorize(Roles ="admin")]
public class AdminController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
	private readonly TagService _tagService;
	private readonly ProductService _productService;
	private readonly CategoryService _categoryService;

	public AdminController(TagService tagService, ProductService productService, CategoryService categoryService)
	{
		_tagService = tagService;
		_productService = productService;
		_categoryService = categoryService;
	}


	public async Task<IActionResult> Register()
	{

		ViewBag.Tags = await _tagService.GetTagsAsync();
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Register(ProductRegistrationViewModel viewmodel, string[] tags)
	{
		if (ModelState.IsValid)
		{
			var result = await _productService.CreateAsync(viewmodel);
			if (result)
			{
				await _productService.AddProductTagsAsync(viewmodel, tags);
				await _categoryService.AddProductCategoryAsync(viewmodel);
				return RedirectToAction("Index", "Admin");
			}
			ModelState.AddModelError("", "Something went wrong");

		}
		ViewBag.Tags = await _tagService.GetTagsAsync(tags);
		return RedirectToAction("Register", "Admin");
	}
}
