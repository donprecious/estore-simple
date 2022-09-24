using PassMerchantMiddleware.Application.Common.Models;

namespace PassMerchantMiddleware.Application.Order.Models;

public class GetOrderDto : BaseEntityDto
{
    public string CustomerEmail {get; set;  }

    public ShippingAddressDto ShippingAddress { get;  set; }
    
    public virtual ICollection<GetOrderItemDto> OrderItems { get; set; }
    
    public int TotalItem { get; set; } 
    public decimal TotalAmount { get; set; }
}