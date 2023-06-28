using Katalog.Order.Domain.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog.Order.Domain.Infrastructure
{
    public class OrderDbContext:DbContext
    {
        public const string DEFAULT_SCHEMA = "order";
        public OrderDbContext(DbContextOptions<OrderDbContext> options):base(options)
        {

        }
        public DbSet<OrderAggregate.Order> Orders { get; set; }
        public DbSet<OrderAggregate.OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderAggregate.Order>().ToTable("Orders", DEFAULT_SCHEMA);
            modelBuilder.Entity<OrderAggregate.OrderItem>().ToTable("OrderItems", DEFAULT_SCHEMA);

            modelBuilder.Entity<OrderItem>().Property(x => x.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<OrderAggregate.Order>().OwnsOne(x => x.Address).WithOwner();


            base.OnModelCreating(modelBuilder);
        }
    }
}
