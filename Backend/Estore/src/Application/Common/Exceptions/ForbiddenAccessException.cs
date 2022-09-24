using System;

namespace PassMerchantMiddleware.Application.Common.Exceptions
{
    public class ForbiddenAccessException : Exception
    {
        public ForbiddenAccessException() : base()
        {
        }
    }
}