using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OnlineShopMicroService.CartService.WebApi.Interface;
using OnlineShopMicroService.CartService.WebApi.Models.Entities;


namespace OnlineShopMicroService.CartService.WebApi.Persistence;

public class ApplicationDbContext : DbContext , IApplicationDbContext
{
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
      
    }
    
    
     
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}