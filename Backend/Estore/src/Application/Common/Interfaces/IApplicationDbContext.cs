using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PassMerchantMiddleware.Domain.Entities;
using PassMerchantMiddleware.Domain.Entities.OrderAggregate;

namespace PassMerchantMiddleware.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {

        public DbSet<Domain.Entities.Product> Products { get; set; }
        public DbSet<Domain.Entities.OrderAggregate.Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}