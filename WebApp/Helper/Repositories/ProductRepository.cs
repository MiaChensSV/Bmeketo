﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Models.Entity;

namespace WebApp.Helper.Repositories;

public class ProductRepository : Repository<ProductEntity>
{
	private readonly WebContext _context;
	public ProductRepository(WebContext webContext, WebContext context) : base(webContext)
	{
		_context = context;
	}

	public override async Task<IList<ProductEntity>> GetAllAsync()
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
    public IEnumerable<ProductEntity> GetAllByTagName(string tagname)
    {
        var _products = _context.Products
                        .Where(p => p.Tags.Any(t => t.Tag.TagName == tagname))
                        .ToList();
        return _products;
    }

    public override async Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> expression)
	{
		var product = await _context.Products
					.Include(x => x.Tags)
					.ThenInclude(x => x.Tag)
					.FirstOrDefaultAsync(expression);
		return product!;
	}


}
