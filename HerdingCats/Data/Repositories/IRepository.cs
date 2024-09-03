namespace HerdingCats.Data.Repositories;

public interface IRepository<TEntity, TKey> where TEntity : class
{
    public Task AddAsync(TEntity entity);
    public Task<IList<TEntity>> GetAllAsync();
    public Task<TEntity?> GetByIdAsync(TKey id);
    public Task RemoveAsync(TEntity entity);
    public Task UpdateAsync(TEntity entity);
}