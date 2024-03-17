//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using e_shop.Models;

namespace e_shop.Services.ProService
{
    internal interface IProductService
    {
        public void ShowAllProducts();
        public Product AddProductToCart(Product product);
        public void CalculateProductCartWithShipping(Shipping shipping);
    }
}