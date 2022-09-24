using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PassMerchantMiddleware.Application.Common.Interfaces;
using PassMerchantMiddleware.Application.Order.Models;

namespace PassMerchantMiddleware.Application.Order.Validators;

public class OrderItemValidator : AbstractValidator<OrderItemDto>
{
    private IApplicationDbContext _context;
    
  
    public OrderItemValidator(IApplicationDbContext context)
    {
        _context = context;
        RuleFor(a => a.Quantity).NotNull().WithMessage("quantity is required");
        RuleFor(a => a.Quantity).Must((int quantity) => quantity > 0).WithMessage("quantity must be greater than 0");
        RuleFor(a => a.ProductId).MustAsync(ProductMustExist).WithMessage("product does not exist");
       
    }

    private Task<bool> ProductMustExist(int productId, CancellationToken cancellationToken)
    {
      var result =  _context.Products.AnyAsync(a => a.Id == productId, cancellationToken);
      return result;
    }
}