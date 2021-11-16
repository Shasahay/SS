using Microsoft.EntityFrameworkCore;
using SS.StudentStore.Services.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SS.StudentStore.Services.Infrastructure.DBContext
{
    public class StoreDBContext : DbContext
    {
        public StoreDBContext(DbContextOptions<StoreDBContext> options): base(options)  {   }

        public DbSet<StoredProcParam> StoredProcParam { get; set; }
        public DbSet<CustomTableTypeColumn> CustomTableTypeColumns { get; set; }
        public DbSet<BasketItem> BasketItem { get; set; }
        public DbSet<BasketView> BasketView { get; set; }
        public DbSet<Basket> Basket { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreDBContext).Assembly);
            modelBuilder.HasDefaultSchema("Store");
            base.OnModelCreating(modelBuilder);
        }
    }
}
