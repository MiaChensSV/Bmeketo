using WebApp.Contexts;
using WebApp.Models.Entity;

namespace WebApp.Helper.Repositories;

public class CategoryRepository : Repository<CategoryEntity>
{
	public CategoryRepository(WebContext webContext) : base(webContext)
	{
	}
}
