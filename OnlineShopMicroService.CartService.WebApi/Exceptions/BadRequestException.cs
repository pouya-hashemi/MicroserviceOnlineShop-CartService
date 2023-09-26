using System.Net;

namespace OnlineShopMicroService.CartService.WebApi.Exceptions;

public class BadRequestException : ExceptionBase
{
    public BadRequestException(string message) : base(message)
    {
        HttpStatusCode = HttpStatusCode.BadRequest;
    }
}