using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
namespace TimeExam.Module
{
    class appDbContext : DbContext
    {
        public DbSet<Materials> Materials;
        public DbSet<MaterialSuppliers> MaterialSuppliers;
        public DbSet<MaterialType> MaterialType;
        public DbSet<ProductType> ProductType;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = timeexam.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Materials>(entity =>
            {
                entity.HasKey(f => f.Id);
                entity.HasOne(f => f.materialType).WithMany(f => f.Materials);
            }
            );
            modelBuilder.Entity<ProductType>(entity => { entity.HasKey(h => h.Id); });
            
        }

    }
}
