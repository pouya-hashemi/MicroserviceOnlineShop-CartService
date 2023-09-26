using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopMicroService.CartService.WebApi.Models.Entities;


[Table("Carts")]
public class Cart 
{
    public int CartId { get; set; }
    
    public Guid Token { get; set; }
    
    public int CustomerId { get; set; }
    
    public DateTime DateCreated { get; set; }


    #region Relationships

    public  ICollection<CartItem> cartItems { get; set; }

    #endregion
    
    
}