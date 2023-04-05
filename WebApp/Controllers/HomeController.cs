using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Entity;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {

        ViewData["Title"] = "Home";
        var viewModel = new HomeIndexViewModel()
        {

            BestCollection = new GridCollectionViewModel()
            {
                Title = "bEST collectjion",
                Categories = new List<string> { "all", "bags", "dresses", "decorations" },
                GridItems = new List<GridCollectionItemViewModel>
                {
                    new GridCollectionItemViewModel()
                    {
                        Id="1",Title="aPPLE WATH COLLECTION",Price=30,ImageUrl="images/placeholders/270*295.svg"
                    },
                        new GridCollectionItemViewModel()
                    {
                        Id="2",Title="samsung WATH COLLECTION",Price=30,ImageUrl="images/placeholders/270*295.svg"
                    },
                },
            },
          
        };
        return View(viewModel);
    }
}
