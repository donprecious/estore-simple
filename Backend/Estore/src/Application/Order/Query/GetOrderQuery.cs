using MediatR;
using PassMerchantMiddleware.Application.Common.Models;
using SharedKernel.Model;

namespace PassMerchantMiddleware.Application.Order.Query;

public class GetOrderQuery : PaginationParameter, IRequest<BaseResponse>
{
    
}