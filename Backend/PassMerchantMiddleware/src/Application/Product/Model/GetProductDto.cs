using AutoMapper;
using PassMerchantMiddleware.Application.Common.Models;
using PassMerchantMiddleware.Domain.Common;
using SharedKernel.Model;

namespace PassMerchantMiddleware.Application.Product.Model;

public class GetProductDto: BaseEntityDto
{
   
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string ImageUrl { get; private set; }
    public decimal Amount { get; set; }
    
}

public class GetProductProfile: Profile 
{
    public GetProductProfile()
    {
        CreateMap<Domain.Entities.Product, GetProductDto>().ReverseMap();
    }

}

