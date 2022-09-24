using MediatR;
using PassMerchantMiddleware.Application.Order.Models;
using SharedKernel.Model;

namespace PassMerchantMiddleware.Application.Order.Command;

public class CreateOrderCommand: IRequest<BaseResponse>
{
    public string CustomerEmail { get; set; }
    public ShippingAddressDto ShippingAddress { get; set; }
    public List<OrderItemDto>  OrderItems { get; set; }
}