using MediatR;
using Microsoft.EntityFrameworkCore;
using PassMerchantMiddleware.Application.Common.Interfaces;
using SharedKernel.Model;

namespace PassMerchantMiddleware.Application.Overview.Query;

public class GetOverviewQueryHandler : IRequestHandler<GetOverviewQuery, BaseResponse>
{
    private IApplicationDbContext _context;

    public GetOverviewQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public  async Task<BaseResponse> Handle(GetOverviewQuery request, CancellationToken cancellationToken)
    {
        var uniqueUser = await _context.Orders.Select(a => a.CustomerEmail).Distinct().CountAsync(cancellationToken);
        var sales = await _context.OrderItems.SumAsync(a => a.Product.Amount * a.Quantity, cancellationToken);
        var orders = await _context.Orders.CountAsync(cancellationToken);
        var response = new { uniqueUser, sales, orders }; 
        return BaseResponse.Ok(response);
    }
}