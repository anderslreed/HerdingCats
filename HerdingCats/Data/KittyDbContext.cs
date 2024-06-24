using HerdingCats.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace HerdingCats.Data
{

public class KittyDbContext : DbContext
{
    public DbSet<Address> Adresses { get; set; }

    public DbSet<Report> Reports { get; set; }
}

}