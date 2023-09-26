namespace OnlineShopMicroService.CartService.WebApi.Exceptions;

public class NotFoundException : ExceptionBase
{
    public NotFoundException(string message) : base(message)
    {

        HttpStatusCode = System.Net.HttpStatusCode.NotFound;
    }
}