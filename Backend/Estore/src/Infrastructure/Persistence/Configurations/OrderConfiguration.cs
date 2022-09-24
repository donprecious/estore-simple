using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PassMerchantMiddleware.Domain.Entities.OrderAggregate;


namespace Persistence.Configurations;

public class OrderConfiguration:  IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
            .OwnsOne(o => o.ShippingAddress);

        builder.OwnsOne(p => p.ShippingAddress)
            .Property(p => p.Street).HasColumnName("ShippingStreet");
        builder.OwnsOne(p => p.ShippingAddress)
            .Property(p => p.City).HasColumnName("ShippingCity");
        builder.OwnsOne(p => p.ShippingAddress)
            .Property(p => p.Country).HasColumnName("ShippingCountry");
        builder.OwnsOne(p => p.ShippingAddress)
            .Property(p => p.State).HasColumnName("ShippingState");
        builder.OwnsOne(p => p.ShippingAddress)
            .Property(p => p.ZipCode).HasColumnName("ShippingZipCode");

    }
}