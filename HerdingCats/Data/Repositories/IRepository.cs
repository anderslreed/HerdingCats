using Microsoft.EntityFrameworkCore;

namespace HerdingCats.Data.Repositories;

/// <summary>
/// Provides CRUD operations for an entity class
/// </summary>
/// <typeparam name="TEntity">Type of mapped entity</typeparam>
/// <typeparam name="TKey">Type entity uses as primary key</typeparam>
public interface IRepository<TEntity, TKey> where TEntity : class
{
    /// <summary>
    /// Add a previously unstored instance, along with any new chid entities it has
    /// </summary>
    /// <param name="entity">The object to add</param>
    public Task AddAsync(TEntity entity);

    /// <summary>
    /// Get all stored instances
    /// </summary>
    /// <returns>List of all entities</returns>
    public Task<IList<TEntity>> GetAllAsync();

    /// <summary>
    /// Get a stored instance by its primary key
    /// </summary>
    /// <param name="id">Primary key value</param>
    /// <returns>The stored instance if it exists, otherwise null</returns>
    public Task<TEntity?> GetByIdAsync(TKey id);

    /// <summary>
    /// Remove a stored instance
    /// </summary>
    /// <param name="entity">The instance to remove</param>
    public Task RemoveAsync(TEntity entity);

    /// <summary>
    /// Update the properties and children of a stored instance
    /// </summary>
    /// <param name="entity">The instance to update</param>
    public Task UpdateAsync(TEntity entity);
}

public class Repository<TEntity, TKey>(DbContext dbContext, DbSet<TEntity> dbSet) : IRepository<TEntity, TKey> where TEntity : class
{
    protected readonly DbContext context = dbContext;
    protected readonly DbSet<TEntity> entitySet = dbSet;

    /// </inheritdoc>
    public async Task AddAsync(TEntity entity)
    {
        await context.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    /// </inheritdoc>
    public async Task<IList<TEntity>> GetAllAsync() => await entitySet.ToListAsync();

    /// </inheritdoc>
    public virtual async Task<TEntity?> GetByIdAsync(TKey id) => await context.FindAsync<TEntity>(id);

    /// </inheritdoc>
    public async Task RemoveAsync(TEntity entity)
    {
        context.Remove(entity);
        await context.SaveChangesAsync();
    }

    /// </inheritdoc>
    public virtual async Task UpdateAsync(TEntity entity)
    {
        context.Update(entity);
        await context.SaveChangesAsync();
    }
}