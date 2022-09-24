using System;

namespace PassMerchantMiddleware.Application.Common.Interfaces
{
    public interface IDateTime
    {
        DateTime Now { get; }
    }
}