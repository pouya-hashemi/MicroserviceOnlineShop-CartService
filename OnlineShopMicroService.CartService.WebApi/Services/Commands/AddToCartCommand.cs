using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShopMicroService.CartService.WebApi.Exceptions;
using OnlineShopMicroService.CartService.WebApi.Interface;
using OnlineShopMicroService.CartService.WebApi.Models.Entities;

namespace OnlineShopMicroService.CartService.WebApi.Services.Commands;

public class AddToCartCommand : IRequest<string>
{
    public Guid Token { get; set; }
    public int CustomerId { get; set; }
    public long ProductIds { get; set; }
    public int Quantities { get; set; }
}

public class AddCartHandler : IRequestHandler<AddToCartCommand, string>
{
    private readonly IApplicationDbContext _context;


    public AddCartHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> Handle(AddToCartCommand request, CancellationToken cancellationToken)
    {
        var cartExisted = _context.Carts.FirstOrDefault(w => w.CustomerId == request.CustomerId);
        
        

        if (cartExisted != null)
        {
            if (request.Quantities < 1)
            {
                throw new BadRequestException("count of products can not be less than one");
            }

            var item = new CartItem()
            {
                CartId = cartExisted.CartId,
                Quantity = request.Quantities,
                ProductId = request.ProductIds,
    
            };
            _context.CartItems.Add(item);
            
           
        }
        else
        {
            
            var cart = new Cart()
            {
                CustomerId = request.CustomerId,
                DateCreated = DateTime.Today,
                Token = request.Token,
                
            };

            _context.Carts.Add(cart);
            
            await _context.SaveChangesAsync(cancellationToken);

            if (request.Quantities < 1)
            {
                throw new BadRequestException("count of products can not be less than one");
            }

            var item = new CartItem()
            {
                CartId = cart.CartId,
                Quantity = request.Quantities,
                ProductId = request.ProductIds,
                
            };
            _context.CartItems.Add(item);
        }


        await _context.SaveChangesAsync(cancellationToken);

        return "Success";
    }
}