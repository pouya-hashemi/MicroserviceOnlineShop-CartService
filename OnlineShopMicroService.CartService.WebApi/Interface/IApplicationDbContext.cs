namespace OnlineShopMicroService.CartService.WebApi.Interface;

public interface IApplicationDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}