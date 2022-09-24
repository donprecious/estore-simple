using PassMerchantMiddleware.Application.Common.Interfaces;

namespace Services.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}