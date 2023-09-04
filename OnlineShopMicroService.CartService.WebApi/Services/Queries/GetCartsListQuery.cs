using System.Linq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShopMicroService.CartService.WebApi.Interface;
using OnlineShopMicroService.CartService.WebApi.Models.Dtos;

namespace OnlineShopMicroService.CartService.WebApi.Services.Queries;

public class GetCartsListQuery : IRequest<List<CartsDto> >
{
    public int? CartId { get; set; }
    public int? CustomerId { get; set; }
    public int? ProductId { get; set; }

    public int PageSize { get; set; } = 1;

    public int PageNumber { get; set; } = 10;
}


public class GetCartsListHandler : IRequestHandler<GetCartsListQuery,List<CartsDto> >
{
    private readonly IApplicationDbContext _context;

    public GetCartsListHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<CartsDto>> Handle(GetCartsListQuery request, CancellationToken cancellationToken=default)
    {
        var query =   _context.CartItems
            .Include(i => i.cart)
            .AsQueryable();

        if (request.CustomerId!=null)
        {
            query = query.Where(w => w.cart.CustomerId == request.CustomerId);
        }

        if (request.CartId!=null)
        {
            query = query.Where(w => w.CartId == request.CartId);
        }

        if (request.ProductId!=null)
        {
            query = query.Where(w => w.ProductId == request.ProductId);
        }
        


        var sumQuantity = query.Sum(s => s.Quantity);

        var list = await query
            .OrderBy(o => o.CartId)
            .Skip((request.PageNumber -1) * request.PageSize)
            .Take(request.PageSize)
            .Select(s => new CartsDto()
            {
                CartId = s.CartId,
                ProductId = s.ProductId,
                Quantity = s.Quantity,
                CustomerId = s.cart.CustomerId,
                SumQuantity = sumQuantity,
                CartItemId = s.CartItemId,

            }).ToListAsync(cancellationToken);


        return list;

    }
}