namespace WebApp.ViewModels;

public class GridCollectionItemViewModel
{
    private decimal _price = 0;
    public string Id { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public string Title { get; set; } = null!;
    public decimal Price
    {
        get { return _price; }
        set { _price = Math.Round(value, 2); }
    }
}
