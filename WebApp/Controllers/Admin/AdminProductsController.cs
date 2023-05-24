using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Helper.Services;
using WebApp.Models.Entity;
using WebApp.ViewModels.Admin.Products;

namespace WebApp.Controllers;
[Authorize(Roles ="admin,manager")]

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
		var product = await _productService.GetAsync(viewmodel.ArticleNumber);

		if (product!=null)
		{
			ModelState.AddModelError("", "ArticleNumber is already exist");
		}
		else if (ModelState.IsValid)
		{
			var _productModel = await _productService.CreateAsync(viewmodel);
            if (_productModel != null)
            {
                if (viewmodel.ImageFile != null)
                {
                    await _productService.UploadImageAsync(_productModel, viewmodel.ImageFile);
                }
                await _productService.AddProductTagsAsync(viewmodel, tags);
                return RedirectToAction("Index", "AdminProducts");
            }
		}
		
		ModelState.AddModelError("", "Input are not all valid");		
		ViewBag.Tags = await _tagService.GetTagsAsync(tags);
		return View(viewmodel);	
    }

    [HttpGet]
	[Route("product/edit/{articleNumber}")]
	public async Task<IActionResult> EditAsync(string articleNumber)
	{
		if (ModelState.IsValid)
		{
			ViewBag.Tags = await _tagService.GetProductTagsAsync(articleNumber);
			ProductRegistrationViewModel _productRegistrationViewModel = await _productService.GetAsync(articleNumber);

			if (_productRegistrationViewModel != null)
			{
				_productRegistrationViewModel.CategoryName =(await _categoryService.GetProductCategoryAsync(articleNumber)).CategoryName;
				return View(_productRegistrationViewModel);
			}
		}
		return RedirectToAction("Admin", "AdminProducts");
	}

	[HttpPost]
	[Route("product/edit/{articleNumber}")]

	public async Task<IActionResult> EditAsync(ProductRegistrationViewModel viewmodel, string[] tags)
	{
		if (ModelState.IsValid)
		{
			ProductEntity _productEntity = await _productService.UpdateAsync(viewmodel);
			if (_productEntity != null)
			{
				if (viewmodel.ImageFile != null)
				{
					await _productService.UploadImageAsync(_productEntity, viewmodel.ImageFile!);
				}
				await _productService.UpdateProductTagsAsync(viewmodel, tags);
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
