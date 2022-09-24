using FluentValidation;
using PassMerchantMiddleware.Application.Product.Commands;

namespace PassMerchantMiddleware.Application.Product.Validators;

public class CreateProductCommandHandler : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandHandler()
    {
        RuleFor(a => a.Name).NotEmpty().NotNull()
            .WithMessage("Product name is required"); 
        RuleFor(a=>a.ImageUrl).NotEmpty().NotEmpty()
            .WithMessage("Image Url  is required");
        RuleFor(a => a.ImageUrl).Must(MustBeValidUrl)
            .WithMessage("Image url  is must be valid"); 
    }

    private bool MustBeValidUrl(string url)
    {
        Uri uriResult;
        bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                      && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        return result;
    }
}