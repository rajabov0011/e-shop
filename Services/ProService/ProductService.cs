//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using e_shop.Brokers.Loggings;
using e_shop.Brokers.Storages.ProductStorageBroker;
using e_shop.Models;
using e_shop.Services.Order;

namespace e_shop.Services.ProService
{
    internal class ProductService : IProductService
    {
        private readonly MemoryStorageBroker memoryStorageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IShippingService shippingService;

        public ProductService()
        {
            this.memoryStorageBroker = new MemoryStorageBroker();
            this.loggingBroker = new LoggingBroker();
            this.shippingService = new ShippingService();
        }

        public void ShowAllProducts()
        {
            List<Product> products = this.memoryStorageBroker.GetCartProducts();
            int count = 1;
            foreach (Product product in products)
            {
                this.loggingBroker.LogInformation($"{count}. {product.Name} - {product.Price}");
                count++;
            }

            this.loggingBroker.LogInformation("===== End of products =====");
        }

        public Product AddProductToCart(Product product)
        {
            return product is null
                ? AddInvalidProduct()
                : ValidateAndAddProduct(product);
        }

        public void CalculateProductCartWithShipping(Shipping shipping)
        {
            List<Product> products = this.memoryStorageBroker.GetCartProducts();
            int summaProducts = 0;
            double summaShipping = 0;
            foreach (Product product in products)
            {
                int sum = Convert.ToInt32(product.Price) * Convert.ToInt32(product.Weight);
                summaProducts += sum;
                summaShipping += this.shippingService.GetCost(shipping,product);
            }

            ShowAllProducts();

            Console.WriteLine($"Total price of Products:  {summaProducts}");
            Console.WriteLine($"Total price of Shipping:  {summaShipping}");
            Console.WriteLine($"Total price of Products with Shipping:  {summaProducts + summaShipping}");
            loggingBroker.LogSucces("===== Thanks for Shopping =====");
        }

        private Product AddInvalidProduct()
        {
            this.loggingBroker.LogError("Product is invalid");

            return new Product();
        }

        private Product ValidateAndAddProduct(Product product) 
        {
            if (String.IsNullOrWhiteSpace(product.Name)
                || product.Weight is 0)
            {
                this.loggingBroker.LogError("Contact details missing.");

                return new Product();
            }
            else
            {
                return this.memoryStorageBroker.AddToCart(product);
            }
        }
    }
}