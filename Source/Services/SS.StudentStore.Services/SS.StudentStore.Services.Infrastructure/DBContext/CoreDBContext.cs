using Microsoft.EntityFrameworkCore;
using SS.StudentStore.Services.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SS.StudentStore.Services.Infrastructure.DBContext
{
    public class CoreDBContext : DbContext
    {
        public CoreDBContext(DbContextOptions<CoreDBContext> options) : base(options) { }

        public DbSet<StoredProcParam> StoredProcParam { get; set; }
        public DbSet<CustomTableTypeColumn> CustomTableTypeColumns { get; set; }
        public DbSet<Product> Product{ get; set; }
        public DbSet<AddressType> AddressType { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }

        public DbSet<ProductView> ProductView { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<ProductTypeMapping> ProductTypeMapping { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CoreDBContext).Assembly);
            modelBuilder.HasDefaultSchema("Core");
            modelBuilder.Entity<ProductView>(eb => eb.HasNoKey());
            base.OnModelCreating(modelBuilder);
        }
    }
}
