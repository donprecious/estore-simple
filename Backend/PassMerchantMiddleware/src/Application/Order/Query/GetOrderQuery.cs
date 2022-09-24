using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PassMerchantMiddleware.Application.Common.Interfaces;
using PassMerchantMiddleware.Application.Common.Models;
using PassMerchantMiddleware.Application.Order.Models;
using SharedKernel.Model;

namespace PassMerchantMiddleware.Application.Order.Query;

public class GetOrderQuery : PaginationParameter, IRequest<BaseResponse>
{
    
}

public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, BaseResponse>
{
    private IApplicationDbContext _context;
    private IMapper _mapper;

    public GetOrderQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponse> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var ordersQuery = _context.Orders
            .Include(a => a.OrderItems)
            .ThenInclude(a => a.Product)
            .ProjectTo<GetOrderDto>(_mapper.ConfigurationProvider).OrderByDescending(a=>a.CreatedAt);
       
        
        var orders  = await PaginatedList<GetOrderDto>.CreateAsync(ordersQuery, request.Page, request.PageSize);
        orders.Items.ForEach(a =>
        {
            a.TotalAmount = a.OrderItems.Sum(c => c.Quantity * c.Product.Amount);
            a.TotalItem = a.OrderItems.Count();
        });
        return BaseResponse.Ok(orders);
    }
}