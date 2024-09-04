using HerdingCats.Data.Model;

using Microsoft.EntityFrameworkCore;

namespace HerdingCats.Data.Repositories;

public class CatRepository(KittyDbContext context) : IRepository<Cat, int>
{
    public async Task AddAsync(Cat cat)
    {
        await context.AddAsync(cat);
        await context.SaveChangesAsync();
    }

    public async Task<IList<Cat>> GetAllAsync() => await context.Cats.ToListAsync();

    public async Task<Cat?> GetByIdAsync(int id) => 
        await context.Cats.Where(cat => cat.Id == id)
                          .Include(cat => cat.Address)
                          .ThenInclude(adr => adr!.Cats)
                          .Include(cat => cat.Address)
                          .ThenInclude(adr => adr!.Humans)
                          .FirstAsync();

    public async Task RemoveAsync(Cat cat)
    {
        context.Remove(cat);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Cat cat)
    {
        context.Update(cat);
        await context.SaveChangesAsync();
    }
}