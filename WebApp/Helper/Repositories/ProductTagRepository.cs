using WebApp.Contexts;
using WebApp.Models.Entity;

namespace WebApp.Helper.Repositories;

public class ProductTagRepository : Repository<ProductTagEntity>
{
	public ProductTagRepository(WebContext webContext) : base(webContext)
	{
	}
}
