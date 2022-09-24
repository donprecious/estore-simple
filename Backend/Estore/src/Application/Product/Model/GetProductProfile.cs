using AutoMapper;

namespace PassMerchantMiddleware.Application.Product.Model;

public class GetProductProfile: Profile 
{
    public GetProductProfile()
    {
        CreateMap<Domain.Entities.Product, GetProductDto>().ReverseMap();
    }

}