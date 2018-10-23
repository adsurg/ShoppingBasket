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

        public void AddItem(Product product, int quantity) =>
            _basketItemsByName.Add(product.Name, new BasketItem(product, quantity));
    }
}
