using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Models.Entity;
using WebApp.ViewModels.Admin.Products;

namespace WebApp.Helper.Repositories;

public class ProductRepository : Repository<ProductEntity>
{
	private readonly WebContext _context;
	public ProductRepository(WebContext webContext, WebContext context) : base(webContext)
	{
		_context = context;
	}

	public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
	{
		var products =await  _context.Products
					.Include(x => x.Tags)
					.ThenInclude(x => x.Tag)
					.ToListAsync();
		return products;
	}

	public override async Task<IEnumerable<ProductEntity>> GetAllAsync(Expression<Func<ProductEntity, bool>> expression)
	{
		var products = await _context.Products
					.Include(x => x.Tags)
					.ThenInclude(x => x.Tag)
					.Where(expression)
					.ToListAsync();
		return products;
	}
	//public async Task<IEnumerable<ProductEntity>> GetAllByTagNameAsync(string tagname)
	//{
	//	var products = await _context.Products
	//				.Include(x => x.Tags)
	//				.ThenInclude(x => x.Tag.TagName==tagname)
	//				.ToListAsync();
	//	return products;
	//}

	public override async Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> expression)
	{
		var product = await _context.Products
					.Include(x => x.Tags)
					.ThenInclude(x => x.Tag)
					.FirstOrDefaultAsync(expression);
		return product!;
	}
}
