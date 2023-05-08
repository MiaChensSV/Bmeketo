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
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _webContext.Set<TEntity>().ToListAsync();
    }
    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _webContext.Set<TEntity>().Update(entity);
        await _webContext.SaveChangesAsync();
        return entity;
    }
    public virtual async Task<bool> DeleteAsync(TEntity entity)
    {
        try
        {
            _webContext.Set<TEntity>().Remove(entity);
            await _webContext.SaveChangesAsync();
            return true;
        }
        catch { }
        return false;

    }
}
