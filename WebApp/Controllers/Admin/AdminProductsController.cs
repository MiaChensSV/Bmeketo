using Microsoft.AspNetCore.Mvc;
using WebApp.Helper.Services;
using WebApp.ViewModels.Admin.Products;

namespace WebApp.Controllers;
public class AdminProductsController : Controller
{
	private readonly TagService _tagService;
	private readonly ProductService _productService;
	private readonly CategoryService _categoryService;

	public AdminProductsController(TagService tagService, ProductService productService, CategoryService categoryService)
	{
		_tagService = tagService;
		_productService = productService;
		_categoryService = categoryService;
	}
	[Route("admin/products")]
	public async Task<IActionResult> Index()
	{
		
		return View(await _productService.GetAllAsync());
	}

	[HttpGet]
	[Route("admin/products/create")]
	public async Task<IActionResult> CreateAsync()
	{
		ViewBag.Tags = await _tagService.GetTagsAsync();
		return View();
	}

	[HttpPost]
	[Route("admin/products/create")]
	public async Task<IActionResult> CreateAsync(ProductRegistrationViewModel viewmodel, string[] tags)
	{
		if (ModelState.IsValid)
		{
			var product = await _productService.CreateAsync(viewmodel);
			if (product!=null)
			{
				if(viewmodel.ImageFile!= null)
				{
					await _productService.UploadImageAsync(product, viewmodel.ImageFile!);
				}				
				await _productService.AddProductTagsAsync(viewmodel, tags);
				return RedirectToAction("Index", "AdminProducts");
			}
			ModelState.AddModelError("", "Something went wrong");

		}
		else
		{
			ModelState.AddModelError("", "Input are not all valid");
		}
		ViewBag.Tags = await _tagService.GetTagsAsync(tags);
		return RedirectToAction("Create", "AdminProducts");
	}

	[HttpGet]
	[Route("edit/{articleNumber}")]
	public async Task<IActionResult> EditAsync(string articleNumber)
	{
		if (ModelState.IsValid)
		{
			var _productEntity = await _productService.GetAsync(articleNumber);
			if (_productEntity != null)
			{
				return View(_productEntity);
			}
		}
		return RedirectToAction("Admin", "AdminProducts");
	}

	[HttpPost]
	[Route("edit/{id}")]
	public async Task<IActionResult> EditAsync(ProductRegistrationViewModel viewmodel, string[] tags)
	{
		if (ModelState.IsValid)
		{
			await _categoryService.GetOrCreateCategoryAsync(viewmodel);

			var result = await _productService.UpdateAsync(viewmodel);
			if (result)
			{
				await _productService.AddProductTagsAsync(viewmodel, tags);
				return RedirectToAction("Index", "AdminProducts");
			}
			ModelState.AddModelError("", "Something went wrong");

		}
		ViewBag.Tags = await _tagService.GetTagsAsync(tags);
		return RedirectToAction("Index", "AdminProducts");
	}

	[Route("admin/products/remove/{articleNumber}")]
	public async Task<IActionResult> RemoveAsync(string articleNumber)
	{
		if (ModelState.IsValid)
		{
			var _product = await _productService.GetAsync(articleNumber);
			if (_product != null)
			{
				await _productService.DeleteAsync(articleNumber);
				return RedirectToAction("Index", "AdminProducts");
			}
			ModelState.AddModelError("", "Something went wrong");

		}
		return RedirectToAction("Index", "AdminProducts");
	}
}
