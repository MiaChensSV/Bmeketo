using WebApp.Contexts;
using WebApp.Models.Entity;
using WebApp.ViewModels.Admin.Products;

namespace WebApp.Helper.Repositories;

public class ProductRepository : Repository<ProductEntity>
{
	public ProductRepository(WebContext webContext) : base(webContext)
	{
	}

	
}
