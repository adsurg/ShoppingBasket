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

        [Fact]
        public void WhenAProductsAreAddedAgainThenTheNetTotalShouldBeCorrect()
        {
            var basket = new Basket();

            basket.AddItem(new Product("Dove Soap", 39.99m), 5);
            basket.AddItem(new Product("Dove Soap", 39.99m), 3);

            basket.NetTotal().Should().Be(319.92m);
        }

        [Fact]
        public void WhenAProductsAreAddedAgainThenTheBasketContainsTheCorrectItems()
        {
            var basket = new Basket();

            basket.AddItem(new Product("Dove Soap", 39.99m), 5);
            basket.AddItem(new Product("Dove Soap", 39.99m), 3);

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
                        Quantity = 8
                    }
                });
        }

        [Fact]
        public void TheTaxTotalShouldBeCorrectlyCalculated()
        {
            var basket = new Basket(12.5m);

            basket.AddItem(new Product("Dove Soap", 39.99m), 2);
            basket.AddItem(new Product("Axe Deo", 99.99m), 2);

            basket.TaxTotal().Should().Be(35m);
        }

        [Fact]
        public void TheTotalShouldBeCorrectlyCalculated()
        {
            var basket = new Basket(12.5m);

            basket.AddItem(new Product("Dove Soap", 39.99m), 2);
            basket.AddItem(new Product("Axe Deo", 99.99m), 2);

            basket.Total().Should().Be(314.96m);
        }
    }
}
