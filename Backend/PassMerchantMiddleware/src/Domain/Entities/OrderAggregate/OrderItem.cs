using PassMerchantMiddleware.Domain.Common;
using PassMerchantMiddleware.Domain.Exceptions;

namespace PassMerchantMiddleware.Domain.Entities.OrderAggregate;

public class OrderItem : BaseEntity
{
    public int ProductId { get; private set; } 
    public virtual  Product Product { get; private set; }
    public int Quantity { get; private set; }

    public int OrderId { get; private set; }
    public virtual Order Order { get; private set; }

    public OrderItem()
    {
        
    }
    public OrderItem(int productId, int quantity, int orderId)
    {
        if (quantity < 1) throw new OrderException("quantity is below 1");
        ProductId = productId; 
        Quantity = quantity;
        OrderId = orderId;
    }

    public void AddUnits(int units)
    {
        if (units < 0)
        {
            throw new OrderException("Invalid quantity");
        }

        Quantity += units;
    }
}