using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShopMicroService.CartService.WebApi.Models.Entities;

namespace OnlineShopMicroService.CartService.WebApi.Persistence.Configurations;

public class CartItemsConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(p => p.CartItemId);
        builder.HasOne(p => p.cart)
            .WithMany(p => p.cartItems)
            .HasForeignKey(p => p.CartId);
    }
}