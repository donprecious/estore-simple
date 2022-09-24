using PassMerchantMiddleware.Application.Product.Model;

namespace PassMerchantMiddleware.Application.Order.Models;

public class GetOrderItemDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public GetProductDto Product { get; set; }
    public int Quantity { get; set; }

}