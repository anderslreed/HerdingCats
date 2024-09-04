using HerdingCats.Data.Model;

using Microsoft.EntityFrameworkCore;

namespace HerdingCats.Data.Repositories;

public class HumanRepository(KittyDbContext dbContext) : Repository<Human, int>(dbContext, dbContext.Humans)
{
    public async override Task<Human?> GetByIdAsync(int id) =>
        await entitySet.Where(hu => hu.Id == id)
                       .Include(hu => hu.Address)
                       .ThenInclude(adr => adr.Humans)
                       .Include(hu => hu.Address)
                       .ThenInclude(adr => adr.Cats)
                       .FirstAsync();
}