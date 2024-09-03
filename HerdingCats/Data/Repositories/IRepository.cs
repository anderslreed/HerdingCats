namespace HerdingCats.Data.Repositories;

public interface IRepository<TEntity, TKey> where TEntity : class
{
    public Task AddAsync(TEntity entity);
    public Task<IEnumerable<TEntity>> GetAll();
    public Task<TEntity?> GetByIdAsync(TKey id);
    public Task RemoveAsync(TEntity entity);
    public Task UpdateAsync(TEntity entity);
}
