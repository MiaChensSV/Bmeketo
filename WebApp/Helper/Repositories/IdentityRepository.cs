using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;

namespace WebApp.Helper.Repositories;

public abstract class IdentityRepository<TEntity> where TEntity : class 
{
	private readonly IdentityContext _identityContext;

	protected IdentityRepository(IdentityContext identityContext)
	{
		_identityContext = identityContext;
	}
	public virtual async Task<TEntity> AddAsync(TEntity entity)
	{
		_identityContext.Set<TEntity>().Add(entity);
		await _identityContext.SaveChangesAsync();
		return entity;
	}
	public virtual async Task<TEntity>GetAsync(Expression<Func<TEntity,bool>> expression)
	{
		var entity = await _identityContext.Set<TEntity>().FirstOrDefaultAsync(expression);
		if (entity != null)
		{
			return entity;
		}
		else return null!;
	}
	public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
	{
		return await _identityContext.Set<TEntity>().Where(expression).ToListAsync();
	
	}
	public virtual async Task<TEntity> UpdateAsync(TEntity entity)
	{
		_identityContext.Set<TEntity>().Update(entity);
		await _identityContext.SaveChangesAsync();
		return entity;
	}
	public virtual async Task<bool> DeleteAsync(TEntity entity)
	{
		try
		{
			_identityContext.Set<TEntity>().Remove(entity);
			await _identityContext.SaveChangesAsync();
			return true;
		}
		catch { }
		return false;
		
	}

}

