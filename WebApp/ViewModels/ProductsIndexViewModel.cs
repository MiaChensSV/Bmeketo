namespace WebApp.ViewModels
{
	public class ProductsIndexViewModel
	{
		public string Title { get; set; } 
		public GridCollectionViewModel All { get; set; } = null!;
	}
}
