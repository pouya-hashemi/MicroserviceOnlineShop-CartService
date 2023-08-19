using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OnlineShopMicroService.CartService.WebApi.Interface;

namespace OnlineShopMicroService.CartService.WebApi.Persistence;

public class ApplicationDbContext : DbContext , IApplicationDbContext
{


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    
     
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}