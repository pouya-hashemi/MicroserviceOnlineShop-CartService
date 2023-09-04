namespace OnlineShopMicroService.CartService.WebApi.Models.Entities;

public class CartItem
{
    public int CartItemId { get; set; }
    public int CartId { get; set; }
    
    public long ProductId { get; set; }
    
    public int Quantity { get;  set; }

    #region Relationships

    public Cart cart { get; set; }

    #endregion
    
  
}