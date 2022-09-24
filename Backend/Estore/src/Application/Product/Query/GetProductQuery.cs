using MediatR;
using PassMerchantMiddleware.Application.Common.Models;
using SharedKernel.Model;

namespace PassMerchantMiddleware.Application.Product.Query;

public class GetProductQuery : PaginationParameter, IRequest < BaseResponse > 
{
    
}