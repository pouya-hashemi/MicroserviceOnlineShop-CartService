using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopMicroService.CartService.WebApi.WebUi.Base;


[ApiController]
[Route("[controller]")]

public abstract class OnlineShopMicroServiceBaseController : ControllerBase
{
        
        private IMediator _mediator ;
        
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        
        
  

  
}