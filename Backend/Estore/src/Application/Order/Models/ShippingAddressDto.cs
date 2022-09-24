using AutoMapper;
using PassMerchantMiddleware.Domain.ValueObjects;

namespace PassMerchantMiddleware.Application.Order.Models;

public class ShippingAddressDto 
{
    public string Street { get;  set; }
    public string City { get;  set; }
    public string State { get;  set; }
    public string Country { get;  set; }
    public string ZipCode { get;  set; }
}

