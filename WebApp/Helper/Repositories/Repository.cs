using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;

namespace WebApp.Helper.Repositories;

public abstract class Repository<TEntity>where TEntity : class
{
    private readonly WebContext _webContext;

    protected Repository(WebContext webContext)
    {
        _webContext = webContext;
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        _webContext.Set<TEntity>().Add(entity);
        await _webContext.SaveChangesAsync();
        return entity;
    }
    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        var entity = await _webContext.Set<TEntity>().FirstOrDefaultAsync(expression);
        return entity!;
    }
	public virtual async Task<IList<TEntity>> GetAllAsync()
	{
		return await _webContext.Set<TEntity>().ToListAsync();
	}
	public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _webContext.Set<TEntity>().Where(expression).ToListAsync();
    }
    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
		if (entity != null)
		{
			_webContext.Entry<TEntity>(entity).State = EntityState.Modified;
		}
		_webContext.Set<TEntity>().Update(entity!);
        await _webContext.SaveChangesAsync();
        return entity!;
    }
    public virtual async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var _entity = await GetAsync(expression);
            _webContext.Set<TEntity>().Remove(_entity);
            await _webContext.SaveChangesAsync();
            return true;
        }
        catch { }
        return false;

    }
}
