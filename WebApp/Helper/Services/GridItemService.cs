using System.Linq;
using WebApp.Models.Entity;
using WebApp.ViewModels;

namespace WebApp.Helper.Services;

public class GridItemService
{
    private readonly ProductService _productService;
    private readonly CategoryService _categoryService;

    public GridItemService(ProductService productService, CategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }
    //public async Task<List<GridCollectionItemViewModel>> GetBestCollectionAsync()
    //{
    //    var categoryNameList = new List<string>();
    //    _categoryService.GetAllAsync().Result.ToList<CategoryEntity>().ForEach(el => categoryNameList.Add(el.CategoryName));

    //    var gridList = new List<GridCollectionItemViewModel>();
    //    var _griditems = _productService.GetAllAsync().Result.ToList<ProductEntity>();

    //    //get gridcollectionitems for maximum 8 or the length of the list
    //    for (int i = 0; i < Math.Min(_griditems.Count, 8); i++)
    //    {
    //        gridList.Add(new GridCollectionItemViewModel
    //        {
    //            Id = _griditems[i].ArticleNumber,
    //            ImageUrl = _griditems[i].ImageUrl,
    //            Title = _griditems[i].Title,
    //            Price = _griditems[i].Price,
    //        });
    //    };
    //    return gridList;        
    //}
}
