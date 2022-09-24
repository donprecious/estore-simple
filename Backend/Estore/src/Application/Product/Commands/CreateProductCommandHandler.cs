using MediatR;
using PassMerchantMiddleware.Application.Common.Interfaces;
using SharedKernel.Model;

namespace PassMerchantMiddleware.Application.Product.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseResponse>
{
    private IApplicationDbContext _context;

    public CreateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<BaseResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Domain.Entities.Product(request.Name, request.Description, request.ImageUrl, request.Amount);
        await   _context.Products.AddAsync(product, cancellationToken);
        await  _context.SaveChangesAsync(cancellationToken); 
      
        return BaseResponse.Ok(null, "product added successfully");
    }
}