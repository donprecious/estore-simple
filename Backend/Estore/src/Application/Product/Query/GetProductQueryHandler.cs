using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using PassMerchantMiddleware.Application.Common.Interfaces;
using PassMerchantMiddleware.Application.Common.Models;
using PassMerchantMiddleware.Application.Product.Model;
using SharedKernel.Model;

namespace PassMerchantMiddleware.Application.Product.Query;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery,BaseResponse>
{
    private IApplicationDbContext _context;
    private IMapper _mapper;
    public GetProductQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var productQuery = _context.Products.ProjectTo<GetProductDto>(_mapper.ConfigurationProvider).OrderByDescending(a=>a.CreatedAt);
        var products = await PaginatedList<GetProductDto>.CreateAsync(productQuery, request.Page, request.PageSize);
        return BaseResponse.Ok(products);
    }
}