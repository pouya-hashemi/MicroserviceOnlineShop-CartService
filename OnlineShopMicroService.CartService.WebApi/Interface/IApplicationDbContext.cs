using Microsoft.EntityFrameworkCore;
using OnlineShopMicroService.CartService.WebApi.Models.Entities;


namespace OnlineShopMicroService.CartService.WebApi.Interface;

public interface IApplicationDbContext
{
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}