//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using e_shop.Models;

namespace e_shop.Brokers.Storages.ProductStorageBroker
{
    internal class MemoryStorageBroker : IMemoryStorageBroker
    {
        static List<Product> cartProducts = new List<Product>();

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>
            {
                new Product{Name = "Apple", Price = 25000},
                new Product{Name = "Banana", Price = 20000},
                new Product{Name = "Orange", Price = 35000},
                new Product{Name = "Kiwi", Price = 30000},
                new Product{Name = "Granate", Price = 25000}
            };

            return products;
        }

        public Product AddToCart(Product product)
        {
            cartProducts.Add(product);
            return product;
        }

        public List<Product> GetCartProducts() =>
            cartProducts;
    }
}