using FluentValidation;
using PassMerchantMiddleware.Application.Order.Models;

namespace PassMerchantMiddleware.Application.Order.Validators;

public class ShippingAddressValidator: AbstractValidator<ShippingAddressDto>
{
    public ShippingAddressValidator()
    {
        RuleFor(a => a.City).NotEmpty().WithMessage("City is required");
        RuleFor(a => a.Country).NotEmpty();
        RuleFor(a => a.State).NotEmpty();
        RuleFor(a => a.Street).NotEmpty();
    
    }
}