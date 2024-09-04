using HerdingCats.Data.Model;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace HerdingCats.Data
{

    public class KittyDbContext(DbContextOptions<KittyDbContext> options) : 
        IdentityDbContext<Human, IdentityRole<int>, int>(options)
    {
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Human> Humans { get; set; }
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