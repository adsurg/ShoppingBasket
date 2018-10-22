using Xunit;
using FluentAssertions;

namespace ShoppingBasket.Test
{
    public class BasketTests
    {
        [Fact]
        public void TheNetTotalStartsAtZero()
        {
            var basket = new Basket();
            
            basket.NetTotal().Should().Be(0m);
        }
    }
}
