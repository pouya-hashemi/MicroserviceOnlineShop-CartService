using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShopMicroService.CartService.WebApi.Exceptions;
using OnlineShopMicroService.CartService.WebApi.Interface;

namespace OnlineShopMicroService.CartService.WebApi.Services.Commands;

public class DeleteCartItemCommand : IRequest<string>
{
    public int CartId { get; set; }
}

public class DeleteCartItemHandler : IRequestHandler<DeleteCartItemCommand, string>
{
    private readonly IApplicationDbContext _context;

    public DeleteCartItemHandler(IApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<string> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
    {
        var cartItem = await _context.CartItems.Where(w => w.CartId == request.CartId)
            .ToListAsync(cancellationToken: cancellationToken);
     

        if (cartItem == null)
        {
            throw new NotFoundException("Items of cart Not Found");
        }
        
        _context.CartItems.RemoveRange(cartItem);

        await _context.SaveChangesAsync(cancellationToken);

        return "Success";


    }
}