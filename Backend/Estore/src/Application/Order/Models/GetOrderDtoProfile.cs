using AutoMapper;

namespace PassMerchantMiddleware.Application.Order.Models;

public class GetOrderDtoProfile : Profile
{
    public GetOrderDtoProfile()
    {
        CreateMap<GetOrderDto, Domain.Entities.OrderAggregate.Order>().ReverseMap();
        
    
    }
}