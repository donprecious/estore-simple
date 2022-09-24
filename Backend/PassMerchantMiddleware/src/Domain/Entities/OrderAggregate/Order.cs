using PassMerchantMiddleware.Domain.Common;
using PassMerchantMiddleware.Domain.ValueObjects;

namespace PassMerchantMiddleware.Domain.Entities.OrderAggregate;

public class Order : BaseEntity, IAggregateRoot
{
    public Order()
    {
        
    }
    public string CustomerEmail { get; private set; }

    public Address ShippingAddress { get; private set; }
  
    public virtual ICollection<OrderItem> OrderItems { get; private set; }
    public Order(string customerEmail, Address shippingAddress)
    {
        CustomerEmail = customerEmail;
        ShippingAddress = shippingAddress;
        OrderItems = new List<OrderItem>();
    }

    public void AddOrderItem(OrderItem orderItem)
    {
        var existingOrderForProduct = OrderItems
            .SingleOrDefault(o => o.ProductId == orderItem.ProductId);

        if (existingOrderForProduct != null)
        {
            //if previous line exist modify it with higher discount  and units..
            
            existingOrderForProduct.AddUnits(orderItem.Quantity);
        }
        else
        {
            //add validated new order item
            OrderItems.Add(new OrderItem(orderItem.ProductId, orderItem.Quantity, Id));
        }
    }
}