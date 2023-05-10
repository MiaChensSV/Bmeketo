using Microsoft.AspNetCore.Mvc;
using WebApp.Helper.Services;
using WebApp.ViewModels.Admin.Products;

namespace WebApp.Controllers;
[Route("admin/products")]
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

	public async Task<IActionResult> Index()
	{
		
		return View(await _productService.GetAllAsync());
	}

	[HttpGet]
	[Route("create")]
	public async Task<IActionResult> CreateAsync()
	{
		ViewBag.Tags = await _tagService.GetTagsAsync();
		return View();
	}

	[HttpPost]
	[Route("create")]
	public async Task<IActionResult> CreateAsync(ProductRegistrationViewModel viewmodel, string[] tags)
	{
		if (ModelState.IsValid)
		{
			var result = await _productService.CreateAsync(viewmodel);
			if (result)
			{
				await _productService.AddProductTagsAsync(viewmodel, tags);
				return RedirectToAction("Index", "AdminProducts");
			}
			ModelState.AddModelError("", "Something went wrong");

		}
		ViewBag.Tags = await _tagService.GetTagsAsync(tags);
		return RedirectToAction("Create", "AdminProducts");
	}

	//[HttpGet]
	//[Route("edit")]
	//public async Task<IActionResult> EditAsync(Guid id)
	//{
	//	if (ModelState.IsValid)
	//	{
	//		var _productEntity = await _productService.GetAsync(id);
	//		if (_productEntity != null)
	//		{
	//			return View(_productEntity);
	//		}
	//	}
	//	return RedirectToAction("Admin", "AdminProducts");
	//}

	//[HttpPost]
	//[Route("edit")]
	//public async Task<IActionResult> EditAsync(ProductRegistrationViewModel viewmodel, string[] tags)
	//{
	//	if (ModelState.IsValid)
	//	{
	//		await _categoryService.GetOrCreateCategoryAsync(viewmodel);

	//		var result = await _productService.UpdateAsync(viewmodel);
	//		if (result)
	//		{
	//			await _productService.AddProductTagsAsync(viewmodel, tags);
	//			return RedirectToAction("Index", "AdminProducts");
	//		}
	//		ModelState.AddModelError("", "Something went wrong");

	//	}
	//	ViewBag.Tags = await _tagService.GetTagsAsync(tags);
	//	return RedirectToAction("Create", "AdminProducts");
	//}

	//[HttpGet]
	//[Route("remove")]
	//public IActionResult Remove()
	//{
	//	return View();
	//}

	//[HttpPost]
	//[Route("create")]
	//public async Task<IActionResult> RemoveAsync(ProductRegistrationViewModel viewmodel, string[] tags)
	//{
	//	if (ModelState.IsValid)
	//	{
	//		await _categoryService.GetOrCreateCategoryAsync(viewmodel);

	//		var result = await _productService.CreateAsync(viewmodel);
	//		if (result)
	//		{
	//			await _productService.AddProductTagsAsync(viewmodel, tags);
	//			return RedirectToAction("Index", "AdminProducts");
	//		}
	//		ModelState.AddModelError("", "Something went wrong");

	//	}
	//	ViewBag.Tags = await _tagService.GetTagsAsync(tags);
	//	return RedirectToAction("Create", "AdminProducts");
	//}

}
