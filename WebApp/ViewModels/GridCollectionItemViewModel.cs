namespace WebApp.ViewModels;

public class GridCollectionItemViewModel
{
    public string Id { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public string Title { get; set; } = null!;
    public decimal Price { get; set; }
}
