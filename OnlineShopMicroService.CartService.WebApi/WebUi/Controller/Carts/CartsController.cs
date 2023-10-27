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
    public async Task<IActionResult> Create([FromBody]AddToCartCommand request)
    {
        var cart = await Mediator.Send(request);
        return CreatedAtAction("GetById", new { id = cart.Id }, cart);
        
    }
    
    
    //Delete CartItem
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteCartItemCommand()
        {
            CartId=id
        };
        await Mediator.Send(command);
        return NoContent();
    }
    
    
    //Get All CartItem
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetCartsListQuery query)
    {
        var list = await Mediator.Send(query);
        return Ok(list);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var cart= await Mediator.Send(new GetCartsListByIdQuery()
        {
            cartId = id
        });

        if (cart is null)
            return NotFound();

        return Ok(cart);
        
    }

}