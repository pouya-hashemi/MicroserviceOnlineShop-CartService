using Microsoft.AspNetCore.Mvc;
using OnlineShopMicroService.CartService.WebApi.Exceptions;
using OnlineShopMicroService.CartService.WebApi.Models.Dtos;
using OnlineShopMicroService.CartService.WebApi.Services.Commands;
using OnlineShopMicroService.CartService.WebApi.Services.Queries;
using OnlineShopMicroService.CartService.WebApi.WebUi.Base;

namespace OnlineShopMicroService.CartService.WebApi.WebUi.Controller.Carts;

public class CartsController : OnlineShopMicroServiceBaseController
{
    //Create Cart
    [HttpPost]
    public async Task<ActionResult<string>> Add([FromBody]AddToCartCommand request)
    {
        var result = await Mediator.Send(request);
        return result;
        
    }
    
    
    //Delete CartItem
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id,[FromForm] DeleteCartItemCommand command)
    {
        if (command.CartId!=id)
        {
            throw new NotFoundException("CartId Not Found");
        }
        await Mediator.Send(command);
        return NoContent();
    }
    
    
    //Get All CartItem
    [HttpGet]
    public async Task<List<CartsDto>> GetAll([FromQuery] GetCartsListQuery query)
    {
        return await Mediator.Send(query);
        

    }
    
    [HttpGet("{id}")]
    public async Task<List<CartsDto>> GetById(int id)
    {
        return await Mediator.Send(new GetCartsListByIdQuery()
        {
            cartId= id
        });
        
    }


}