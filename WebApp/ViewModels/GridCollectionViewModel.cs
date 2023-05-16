using WebApp.Models.Entity;

namespace WebApp.ViewModels;

public class GridCollectionViewModel
{
    public string Title { get; set; } = "Best Collection";
    public IEnumerable<string> Categories { get; set; } = null!;
    public IEnumerable<GridCollectionItemViewModel> GridItems { get; set; } = new List<GridCollectionItemViewModel>();  
    public bool LoadMore { get; set; } = false;

}
