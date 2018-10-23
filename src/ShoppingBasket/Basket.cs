using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket
{
    public class Basket
    {
        public Basket() : this(0m)
        {
        }

        public Basket(decimal taxRate)
        {
            TaxRate = taxRate;
        }

        public decimal TaxRate { get; }
        public decimal NetTotal() => Math.Round(Items().Sum(item => item.Product.Price * item.Quantity), 2);
        public decimal TaxTotal() => Math.Round(NetTotal() * TaxRate / 100, 2);
        public ICollection<BasketItem> Items() => _basketItemsByName.Values;

        public void AddItem(Product product) =>
            AddItem(product, 1);

        public void AddItem(Product product, int quantity)
        {
            var existingQuantity = _basketItemsByName.TryGetValue(product.Name, out var item) ? item.Quantity : 0;
            _basketItemsByName[product.Name] = new BasketItem(product, quantity + existingQuantity);
        }

        private readonly IDictionary<string, BasketItem> _basketItemsByName = new Dictionary<string, BasketItem>();
    }
}
