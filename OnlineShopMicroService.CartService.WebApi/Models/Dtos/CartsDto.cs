namespace OnlineShopMicroService.CartService.WebApi.Models.Dtos;

public class CartsDto
{
    public int? CartItemId { get; set; }
    
    public int? CartId { get; set; }

    public long? ProductId { get; set; }
    
    public int? Quantity { get;  set; }
    
    public int? CustomerId { get; set; }
    
    public DateTime? DateCreated { get; set; }
    
    public string? CustomerName { get; set; }
    
    public string? ProductName { get; set; }
    
    public int? SumQuantity { get; set; }
    
    public int? SumPrice { get; set; }

}