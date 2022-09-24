using AutoMapper;
using PassMerchantMiddleware.Domain.ValueObjects;

namespace PassMerchantMiddleware.Application.Order.Models;

public class ShippingAddressMappingProfile: Profile
{
    public ShippingAddressMappingProfile()
    {
        CreateMap<Address, ShippingAddressDto>().ReverseMap();
    }
}