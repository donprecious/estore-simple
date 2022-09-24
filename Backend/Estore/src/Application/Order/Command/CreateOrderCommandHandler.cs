using AutoMapper;
using MediatR;
using PassMerchantMiddleware.Application.Common.Interfaces;
using PassMerchantMiddleware.Domain.Entities;
using PassMerchantMiddleware.Domain.Entities.OrderAggregate;
using PassMerchantMiddleware.Domain.ValueObjects;
using SharedKernel.Model;

namespace PassMerchantMiddleware.Application.Order.Command;

public class CreateOrderCommandHandler: IRequestHandler<CreateOrderCommand, BaseResponse>
{
    private IMapper _mapper;
    private IApplicationDbContext _context;
    public CreateOrderCommandHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<BaseResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var shippingAddress = _mapper.Map<Address>(request.ShippingAddress); 
        var orderItems=  _mapper.Map<List<OrderItem>>(request.OrderItems);
        var order = new Domain.Entities.OrderAggregate.Order(request.CustomerEmail, shippingAddress);
        foreach (var orderItem in orderItems)
        {
            order.AddOrderItem(orderItem);
        }
        await _context.Orders.AddAsync(order, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return BaseResponse.Ok(null, "order created successfully");
    }
}