using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ShoppingBasket
{
    public class Basket
    {
        public decimal NetTotal() => Items().Sum(item => item.Product.Price * item.Quantity);
        public ICollection<BasketItem> Items() => BasketItemsByName.Values;
        
        private IDictionary<string, BasketItem> BasketItemsByName = new Dictionary<string, BasketItem>();

        public void AddItem(Product product)
        {
            BasketItemsByName.Add(product.Name, new BasketItem(product,1));
        }
    }
}
