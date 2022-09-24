using AutoMapper;
using PassMerchantMiddleware.Domain.Entities;
using PassMerchantMiddleware.Domain.Entities.OrderAggregate;

namespace PassMerchantMiddleware.Application.Order.Models;

public class OrderItemDtoProfile: Profile
{
    public OrderItemDtoProfile()
    {
        CreateMap<OrderItem, GetOrderItemDto>().ReverseMap();
        CreateMap<OrderItem, OrderItemDto>().ReverseMap();
    }
}