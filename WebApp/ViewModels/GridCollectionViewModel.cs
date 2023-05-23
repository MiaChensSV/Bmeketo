using WebApp.Models.Entity;

namespace WebApp.ViewModels;

public class GridCollectionViewModel
{
    public string? Title { get; set; } 
    public IEnumerable<string>? Categories { get; set; }
    public IEnumerable<GridCollectionItemViewModel> GridItems { get; set; } = new List<GridCollectionItemViewModel>();  
    public bool LoadMore { get; set; } = false;
}
