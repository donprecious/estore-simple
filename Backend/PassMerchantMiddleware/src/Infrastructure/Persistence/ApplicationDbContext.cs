using Microsoft.EntityFrameworkCore;
using PassMerchantMiddleware.Application.Common.Interfaces;
using PassMerchantMiddleware.Domain.Entities;
using PassMerchantMiddleware.Domain.Entities.OrderAggregate;

namespace Persistence
{
   
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
       
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }


      

    }
}