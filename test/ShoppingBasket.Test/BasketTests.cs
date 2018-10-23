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

        [Fact]
        public void WhenAProductIsAddedThenTheNetTotalShouldBeCorrect()
        {
            var basket = new Basket();

            basket.AddItem(new Product("Dove Soap", 39.99m));
            
            basket.NetTotal().Should().Be(39.99m);
        }

        [Fact]
        public void BasketItemsShouldBeImmutable()
        {
            var basket = new Basket();

            basket.AddItem(new Product("Dove Soap", 39.99m));
            
            basket.Items().IsReadOnly.Should().BeTrue();
        }

        [Fact]
        public void WhenAProductIsAddedThenTheBasketContainsTheCorrectItems()
        {
            var basket = new Basket();

            basket.AddItem(new Product("Dove Soap", 39.99m));

            basket.Items().Should().BeEquivalentTo(
                new[]
                {
                    new
                    {
                        Product = new {Name = "Dove Soap"},
                        Quantity = 1
                    }
                });
        }
    }
}
