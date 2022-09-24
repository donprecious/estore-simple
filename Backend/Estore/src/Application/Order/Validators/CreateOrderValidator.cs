using System.Text.RegularExpressions;
using FluentValidation;
using PassMerchantMiddleware.Application.Common.Interfaces;
using PassMerchantMiddleware.Application.Order.Command;

namespace PassMerchantMiddleware.Application.Order.Validators;

public class CreateOrderValidator: AbstractValidator<CreateOrderCommand>
{
    private IApplicationDbContext _context;
  
    public CreateOrderValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(a => a.CustomerEmail).Must(EmailMustBeValid)
            .WithMessage("product does not exist");

        RuleForEach(a => a.OrderItems)
            .SetValidator(new OrderItemValidator(_context));
        
        RuleFor(a => a.ShippingAddress).SetValidator(new ShippingAddressValidator());
    }

    private bool EmailMustBeValid(string email)
    {
        string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

        var result = Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
        return result;
    }
}