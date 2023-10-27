namespace OnlineShopMicroService.CartService.WebApi.Models.Dtos
{
    public class CartReadDto
    {
        public int Id { get; set; }
        public Guid Token { get; set; }
        public int CustomerId { get; set; }
    }
}
