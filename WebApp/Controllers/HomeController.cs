
using Microsoft.AspNetCore.Mvc;
using WebApp.Helper.Services;
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

    public IActionResult Index()
    {
        var viewModel = new HomeViewModel
        {
            Title = "Home",
            BestCollection = new GridCollectionViewModel
            {
                Title = "Best Collection",
                Categories = new List<string> { "all", "bags", "dresses", "decorations" },
                GridItems = new List<GridCollectionItemViewModel>
                {
                   new GridCollectionItemViewModel()
        //            {
        //                Id="1",Title="aPPLE WATH COLLECTION",Price=30,ImageUrl="images/placeholders/270x295.svg"
        //            },
        //                new GridCollectionItemViewModel()
        //            {
        //                Id="2",Title="samsung WATH COLLECTION",Price=30,ImageUrl="images/placeholders/270x295.svg"
        //            },
                }
            }



        };

        //ViewData["Title"] = "Home";
        //var viewModel = new HomeIndexViewModel()
        //{

        //    BestCollection = new GridCollectionViewModel()
        //    {
        //        Title = "BEST collectjion",
        //        Categories = new List<string> { "all", "bags", "dresses", "decorations" },
        //        GridItems = new List<GridCollectionItemViewModel>
        //        {
        //            new GridCollectionItemViewModel()
        //            {
        //                Id="1",Title="aPPLE WATH COLLECTION",Price=30,ImageUrl="images/placeholders/270x295.svg"
        //            },
        //                new GridCollectionItemViewModel()
        //            {
        //                Id="2",Title="samsung WATH COLLECTION",Price=30,ImageUrl="images/placeholders/270x295.svg"
        //            },
        //        },
        //    },

        //};
        return View(viewModel);
    }
}
