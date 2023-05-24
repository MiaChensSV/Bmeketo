using System.Linq;
using WebApp.Models.Entity;
using WebApp.ViewModels;

namespace WebApp.Helper.Services;

public class HomeService
{
    private readonly ProductService _productService;

    public HomeService(ProductService productService)
    {
        _productService = productService;
    }

    public async Task<IEnumerable<GridCollectionItemViewModel>> GetTopItemListAsync()
    {
        var _topSellingList = new List<GridCollectionItemViewModel>();
        var _topitemslist = await _productService.GetAllByTagNameAsync("Popular");
        for (int i = 0; i < Math.Min(_topitemslist.Count, 7); i++)
        {
           _topSellingList.Add(new GridCollectionItemViewModel
            {
                Id = _topitemslist[i].ArticleNumber,
                ImageUrl = _topitemslist[i].ImageUrl,
                Title = _topitemslist[i].Title,
                Price = _topitemslist[i].Price,
            });
        };
        return _topSellingList;
    }
    public IEnumerable<GridCollectionItemViewModel> GetUpToSellList()
    {
        var _griditemslist = _productService.GetAllAsync().Result.ToList<ProductEntity>();

        Random r = new Random();

        int uptoSellRandomNr1 = r.Next(0, _griditemslist.Count);

        GridCollectionItemViewModel upToSellItem1 = new()
        {
            Id = _griditemslist[uptoSellRandomNr1].ArticleNumber,
            ImageUrl = _griditemslist[uptoSellRandomNr1].ImageUrl,
            Title = _griditemslist[uptoSellRandomNr1].Title,
            Price = _griditemslist[uptoSellRandomNr1].Price,
        };

        int uptoSellRandomNr2 = r.Next(0, _griditemslist.Count);
        GridCollectionItemViewModel upToSellItem2 = new()
        {
            Id = _griditemslist[uptoSellRandomNr2].ArticleNumber,
            ImageUrl = _griditemslist[uptoSellRandomNr2].ImageUrl,
            Title = _griditemslist[uptoSellRandomNr2].Title,
            Price = _griditemslist[uptoSellRandomNr2].Price,
        };

        return new List<GridCollectionItemViewModel> { upToSellItem1, upToSellItem2 };
    }
    public IEnumerable<GridCollectionItemViewModel> GetBestCollectionList()
    {
        var gridList = new List<GridCollectionItemViewModel>();
        var _griditemslist = _productService.GetAllAsync().Result.ToList<ProductEntity>();
        for (int i = 0; i < Math.Min(_griditemslist.Count, 8); i++)
        {
            gridList.Add(new GridCollectionItemViewModel
            {
                Id = _griditemslist[i].ArticleNumber,
                ImageUrl = _griditemslist[i].ImageUrl,
                Title = _griditemslist[i].Title,
                Price = _griditemslist[i].Price,
            });
        };
        return gridList;
    }
}
