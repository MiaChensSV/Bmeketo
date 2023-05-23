using WebApp.Models;

namespace WebApp.ViewModels;

public class HomeViewModel
{
	public string Title { get; set; } = "Home";
	public GridCollectionViewModel? BestCollection;
    public GridCollectionItemViewModel? UpToSellItem1;
    public GridCollectionItemViewModel? UpToSellItem2;
    public GridCollectionViewModel? TopSellingCollection;
}
