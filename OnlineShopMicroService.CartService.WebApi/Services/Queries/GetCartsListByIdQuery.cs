using System.Linq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShopMicroService.CartService.WebApi.Exceptions;
using OnlineShopMicroService.CartService.WebApi.Interface;
using OnlineShopMicroService.CartService.WebApi.Models.Dtos;
using OnlineShopMicroService.CartService.WebApi.Services.Queries;

namespace OnlineShopMicroService.CartService.WebApi.Services.Queries;

public class GetCartsListByIdQuery : IRequest<List<CartsDto>>
{
    public int cartId { get; set; }
    
}


public class GetCartsListByIdHandler : IRequestHandler<GetCartsListByIdQuery, List<CartsDto>>
{
    private readonly IApplicationDbContext _context;

    public GetCartsListByIdHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<CartsDto>> Handle(GetCartsListByIdQuery request, CancellationToken cancellationToken)
    {
        var query =   _context.CartItems
            .Include(i => i.cart)
            .Where(w=>w.CartId==request.cartId)
            .AsQueryable();

        if (query==null)
        {
            throw new NotFoundException("Item of Cart not found");
        }

        var list = await query
            .OrderBy(o => o.CartId)
            .Select(s => new CartsDto()
            {
                CartId = s.CartId,
                ProductId = s.ProductId,
                Quantity = s.Quantity,
                CustomerId = s.cart.CustomerId,
                CartItemId = s.CartItemId,

            }).ToListAsync(cancellationToken);


        return list;





    }
}

