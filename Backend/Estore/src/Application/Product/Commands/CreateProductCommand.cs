using MediatR;
using SharedKernel.Model;

namespace PassMerchantMiddleware.Application.Product.Commands;

public class CreateProductCommand : IRequest<BaseResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public string ImageUrl { get; set; }
}