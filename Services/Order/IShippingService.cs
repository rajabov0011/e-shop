//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using e_shop.Models;

namespace e_shop.Services.Order
{
    internal interface IShippingService
    {
        public double GetCost(Shipping shipping, Product product);
        public string GetDate(Shipping shipping);
    }
}