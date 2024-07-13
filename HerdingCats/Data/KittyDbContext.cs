using HerdingCats.Data.Model;

using Microsoft.EntityFrameworkCore;

namespace HerdingCats.Data
{

    public class KittyDbContext(DbContextOptions<KittyDbContext> options) : DbContext(options)
    {
        public DbSet<Address> Adresses { get; set; }

        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasMany(a => a.Cats).WithOne().HasForeignKey("address");
            modelBuilder.Entity<Address>().HasMany(a => a.Humans).WithOne().HasForeignKey("address");
            modelBuilder.Entity<Cat>().HasMany(c => c.Reports).WithOne().HasForeignKey("cat");
            base.OnModelCreating(modelBuilder);
        }
    }

}