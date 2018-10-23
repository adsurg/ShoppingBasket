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

        [Fact]
        public void BasketItemsShouldBeImmutable()
        {
            var basket = new Basket();

            basket.AddItem(new Product("Dove Soap", 39.99m));

            basket.Items().IsReadOnly.Should().BeTrue();
        }

        [Fact]
        public void WhenAProductsAreAddedThenTheNetTotalShouldBeCorrect()
        {
            var basket = new Basket();

            basket.AddItem(new Product("Dove Soap", 39.99m), 5);

            basket.NetTotal().Should().Be(199.95m);
        }

        [Fact]
        public void WhenAProductsAreAddedThenTheBasketContainsTheCorrectItems()
        {
            var basket = new Basket();

            basket.AddItem(new Product("Dove Soap", 39.99m), 5);

            basket.Items().Should().BeEquivalentTo(
                new[]
                {
                    new
                    {
                        Product = new
                        {
                            Name = "Dove Soap",
                            Price = 39.99m
                        },
                        Quantity = 5
                    }
                });
        }
    }
}
