using Microsoft.EntityFrameworkCore;
using SS.StudentStore.Services.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SS.StudentStore.Services.Infrastructure.DBContext
{
    public class StagingDBContext : DbContext
    {
        public StagingDBContext(DbContextOptions<StagingDBContext> options) : base(options) { }
        public DbSet<StoredProcParam> StoredProcParam { get; set; }
        public DbSet<CustomTableTypeColumn> CustomTableTypeColumns { get; set; }
        public DbSet<StagingProductView> StagingProduct { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StagingDBContext).Assembly);
            modelBuilder.HasDefaultSchema("Staging");
            modelBuilder.Entity<StagingProductView>(eb => eb.HasNoKey());
            base.OnModelCreating(modelBuilder);
        }
    }
}
