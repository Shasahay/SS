using Microsoft.EntityFrameworkCore;
using SS.StudentStore.Services.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SS.StudentStore.Services.Infrastructure.DBContext
{
    public class CommonDBContext : DbContext
    {
        public CommonDBContext(DbContextOptions<CommonDBContext> options) : base(options) { }

        public DbSet<StoredProcParam> StoredProcParam { get; set; }
        public DbSet<CustomTableTypeColumn> CustomTableTypeColumns { get; set; }
       // public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CommonDBContext).Assembly);
            modelBuilder.HasDefaultSchema("Common");
            base.OnModelCreating(modelBuilder);
        }
    }
}
