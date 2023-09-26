using System.Net;

namespace OnlineShopMicroService.CartService.WebApi.Exceptions;

public class ExceptionBase : Exception
{
    public HttpStatusCode HttpStatusCode { get; set; }

    public ExceptionBase(string message) : base(message)
    {
        
    }
}