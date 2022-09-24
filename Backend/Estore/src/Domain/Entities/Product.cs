using PassMerchantMiddleware.Domain.Common;

namespace PassMerchantMiddleware.Domain.Entities;

public class Product : BaseEntity
{
    public string Name  { get; private set ; }  
    public string Description  { get; private set; }
    public string ImageUrl { get; private set; }
    public decimal Amount { get; set; }

    public Product(string name , string description,  string imageUrl, decimal amount)
    {
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
        Amount = amount;
    }
  
}