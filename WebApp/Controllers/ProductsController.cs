using Microsoft.AspNetCore.Mvc;
using WebApp.Helper.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class ProductsController : Controller
{
    
	public IActionResult Index()
	{
		return View();
	}
	[Route("{id}")]
	public IActionResult Details(string id)
	{
		return View();
	}

}