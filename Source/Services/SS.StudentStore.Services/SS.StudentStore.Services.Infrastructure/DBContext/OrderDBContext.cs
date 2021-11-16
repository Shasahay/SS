using Microsoft.EntityFrameworkCore;
using SS.StudentStore.Services.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SS.StudentStore.Services.Infrastructure.DBContext
{
    public class OrderDBContext : DbContext
    {
        public OrderDBContext(DbContextOptions<OrderDBContext> options) : base(options) { }

        public DbSet<StoredProcParam> StoredProcParam { get; set; }
        public DbSet<CustomTableTypeColumn> CustomTableTypeColumns { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethod { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<OrderView> OrderView { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderDBContext).Assembly);
            modelBuilder.HasDefaultSchema("Order");
            base.OnModelCreating(modelBuilder);
        }
    }
}
