using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopMicroService.CartService.WebApi.Models.Entities;


public class Cart
{
    public int CartId { get; set; }

    public Guid Token { get; private set; }

    public int CustomerId { get; private set; }

    public DateTime DateCreated { get; private set; }


    public Cart(Guid token, int customerId)
    {
        Token = ValidateToken(token);

    }

    public void SetToken(Guid token)
    {
        this.Token = ValidateToken(token);
    }

    private Guid ValidateToken(Guid token)
    {
        if (token == Guid.Empty)
            throw new ArgumentNullException("token");
        return token;
    }

    #region Relationships

    public ICollection<CartItem> cartItems { get; set; }

    #endregion


}