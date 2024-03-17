//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using e_shop.Models;

namespace e_shop.Services.Order
{
    internal class ShippingService : IShippingService
    {
        public static double GetTotalWeight(Product product) =>
                product.Weight;

        public static void SetShippingType(Shipping shipping, string type) =>
            shipping.Type = type;
        public double GetCost(Shipping shipping, Product product)
        {
            if (shipping.Type == "Ground")
            {
                if (GetTotalWeight(product) > 100)
                {
                    return 0;
                }

                return Math.Max(10, GetTotalWeight(product) * 1.5);
            }

            if (shipping.Type == "Air")
            {
                return Math.Max(20, GetTotalWeight(product) * 3);
            }

            if (shipping.Type == "Sea")
            {
                return Math.Max(25, GetTotalWeight(product) * 5);
            }

            return 0;
        }

        public string GetDate(Shipping shipping) =>
            shipping.Date ?? DateTime.Now.ToString("dd-MM-yyyy");
    }
}