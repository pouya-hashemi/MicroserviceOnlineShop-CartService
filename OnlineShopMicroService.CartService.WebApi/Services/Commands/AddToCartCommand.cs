using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShopMicroService.CartService.WebApi.Exceptions;
using OnlineShopMicroService.CartService.WebApi.Interface;
using OnlineShopMicroService.CartService.WebApi.Models.Dtos;
using OnlineShopMicroService.CartService.WebApi.Models.Entities;

namespace OnlineShopMicroService.CartService.WebApi.Services.Commands;

public class AddToCartCommand : IRequest<CartReadDto>
{
    public Guid Token { get; set; }
    public int CustomerId { get; set; }
    public long ProductIds { get; set; }
    public int Quantities { get; set; }
}

public class AddCartHandler : IRequestHandler<AddToCartCommand, CartReadDto>
{
    private readonly IApplicationDbContext _context;


    public AddCartHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CartReadDto> Handle(AddToCartCommand request, CancellationToken cancellationToken)
    {
        //validation
        var cart = await _context.Carts.FirstOrDefaultAsync(w => w.CustomerId == request.CustomerId);

        if (request.Quantities < 1)
        {
            throw new BadRequestException("count of products can not be less than one");
        }


        if (cart != null)
        {

            var item = new CartItem()
            {
                CartId = cart.CartId,
                Quantity = request.Quantities,
                ProductId = request.ProductIds,

            };
            _context.CartItems.Add(item);


        }
        else
        {

            cart = new Cart(request.Token, request.CustomerId);

            _context.Carts.Add(cart);

            var item = new CartItem()
            {
                CartId = cart.CartId,
                Quantity = request.Quantities,
                ProductId = request.ProductIds,

            };
            _context.CartItems.Add(item);
        }


        await _context.SaveChangesAsync(cancellationToken);

        return new CartReadDto() {
            Id = cart.CartId,
            Token=cart.Token,
            CustomerId=request.CustomerId,
        };
    }
}