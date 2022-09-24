using System.Threading.Tasks;
using PassMerchantMiddleware.Domain.Common;

namespace PassMerchantMiddleware.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}