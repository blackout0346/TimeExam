using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
namespace TimeExam.Module
{
    class appDbContext : DbContext
    {
        public DbSet<Materials> Materials { get; set; }
        public DbSet<MaterialSuppliers> MaterialSuppliers { get; set; }
        public DbSet<MaterialType> MaterialType { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<TypeOrg> TypeOrg { get; set; }
        public DbSet<TypeSuppliers> TypeSuppliers { get; set; }
        public DbSet<PostavshickType> PostavshickType { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = timeexam.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Materials>(entity =>
            {
                entity.HasKey(f => f.Id);
                entity.HasOne(f => f.materialType)
                      .WithMany(f => f.Materials)
                      .HasForeignKey(f => f.MaterialTypeId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.HasKey(h => h.Id);
            });

            modelBuilder.Entity<TypeSuppliers>(entity =>
            {
                entity.HasKey(h => h.Id);
                entity.HasOne(h => h.typeOrg)
                      .WithMany(h => h.TypeSuppliers)
                      .HasForeignKey(h => h.TypeOrgId)
                      .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(h => h.postavshickType)
                      .WithMany(h=> h.Suppliers)
                      .HasForeignKey(h => h.PostavshickTypeId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<MaterialSuppliers>(entity =>
            {
                entity.HasKey(h => h.Id);
                entity.HasOne(h => h.PostavshickType)
                      .WithMany()
                      .HasForeignKey(h => h.PostavshickTypeId)
                      .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(h => h.materials)
                      .WithMany()
                      .HasForeignKey(h => h.MaterialId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

        }
    }
}
