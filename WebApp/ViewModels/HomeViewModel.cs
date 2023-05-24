using WebApp.Models;

namespace WebApp.ViewModels;

public class HomeViewModel
{
	public string Title { get; set; } = "Home";
	public GridCollectionViewModel? BestCollection;
    public GridCollectionViewModel? UpToSellItem;
    public GridCollectionViewModel? TopSellingCollection;
}
