using WebApp.Contexts;
using WebApp.Models.Entity;

namespace WebApp.Helper.Repositories;

public class ProductRepository : Repository<ProductEntity>
{
	public ProductRepository(WebContext webContext) : base(webContext)
	{
	}
}
