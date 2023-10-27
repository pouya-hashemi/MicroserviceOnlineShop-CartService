using OnlineShopMicroService.CartService.WebApi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopMicroService.CartService.WebApi.UnitTests
{
    public class CartTests
    {
        [Fact]
        public void SetToken_ShouldThrowArgumentNullException_WhenTokenIsEmpty()
        {
            //Arrange
            var validToken=Guid.NewGuid();
            var customerId = 1;
            var cart = new Cart(validToken,customerId);
            //Act
            var act=()=> { cart.SetToken(Guid.Empty); };
            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }
    }
}
