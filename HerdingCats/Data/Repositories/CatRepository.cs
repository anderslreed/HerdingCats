using HerdingCats.Data.Model;

using Microsoft.EntityFrameworkCore;

namespace HerdingCats.Data.Repositories;

public class CatRepository(KittyDbContext dbContext) : Repository<Cat, int>(dbContext, dbContext.Cats)
{
    public async override Task<Cat?> GetByIdAsync(int id) => 
        await entitySet.Where(cat => cat.Id == id)
                       .Include(cat => cat.Address)
                       .ThenInclude(adr => adr!.Cats)
                       .Include(cat => cat.Address)
                       .ThenInclude(adr => adr!.Humans)
                       .FirstAsync();
}