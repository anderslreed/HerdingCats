using HerdingCats.Data.Model;

using Microsoft.EntityFrameworkCore;

namespace HerdingCats.Data
{

    public class KittyDbContext(DbContextOptions<KittyDbContext> options) : DbContext(options)
    {
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Address> Adresses { get; set; }

        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cat>().HasOne<Address>();
            modelBuilder.Entity<Human>().HasOne<Address>();
            modelBuilder.Entity<Cat>().HasMany(c => c.Reports).WithOne().HasForeignKey("cat");
            base.OnModelCreating(modelBuilder);
        }
    }

}