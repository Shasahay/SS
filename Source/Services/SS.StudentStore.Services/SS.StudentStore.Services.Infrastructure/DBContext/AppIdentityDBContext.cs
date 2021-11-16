using Microsoft.EntityFrameworkCore;
using SS.StudentStore.Services.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SS.StudentStore.Services.Infrastructure.DBContext
{
    public class AppIdentityDBContext : DbContext
    {
        public AppIdentityDBContext(DbContextOptions<AppIdentityDBContext> options) : base(options) { }

        public DbSet<StoredProcParam> StoredProcParam { get; set; }
        public DbSet<CustomTableTypeColumn> CustomTableTypeColumns { get; set; }

        public DbSet<Users> Users { get; set; }
        public DbSet<UserView> UserView { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<AddressType> AddressType { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppIdentityDBContext).Assembly);
            modelBuilder.HasDefaultSchema("AppIdentity");
            base.OnModelCreating(modelBuilder);
        }
    }
}
