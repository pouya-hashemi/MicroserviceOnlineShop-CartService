using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShopMicroService.CartService.WebApi.Models.Entities;

namespace OnlineShopMicroService.CartService.WebApi.Persistence.Configurations;

public class CartsConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable("Carts")
        builder.HasKey(p => p.CartId);
       

    }
}