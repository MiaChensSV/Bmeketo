using System.Linq.Expressions;
using WebApp.Contexts;
using WebApp.Models.Entity;

namespace WebApp.Helper.Repositories;

public class ProductTagRepository : Repository<ProductTagEntity>
{
	private readonly WebContext _webContext;
	public ProductTagRepository(WebContext webContext) : base(webContext)
	{
		_webContext = webContext;

	}

	public void Delete(ProductTagEntity entity)
	{
		_webContext.ProductTags.Remove(entity);
	}
}
