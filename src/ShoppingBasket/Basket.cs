using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket
{
    public class Basket
    {
        public decimal NetTotal() => Items().Sum(item => item.Product.Price * item.Quantity);
        public ICollection<BasketItem> Items() => _basketItemsByName.Values;

        private readonly IDictionary<string, BasketItem> _basketItemsByName = new Dictionary<string, BasketItem>();

        public void AddItem(Product product) =>
            AddItem(product, 1);

        public void AddItem(Product product, int quantity)
        {
            var existingQuantity = _basketItemsByName.TryGetValue(product.Name, out var item) ? item.Quantity : 0;
            _basketItemsByName[product.Name] = new BasketItem(product, quantity + existingQuantity);
        }
    }
}
