//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using e_shop.Models;
using System;

namespace e_shop.Brokers.Storages.ProductStorageBroker
{
    internal interface IMemoryStorageBroker
    {
        public List<Product> GetAllProducts();
        public Product AddToCart(Product product);
        public List<Product> GetCartProducts();
    }
}