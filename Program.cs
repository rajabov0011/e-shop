//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using e_shop.Models;
using e_shop.Brokers.Loggings;
using e_shop.Services.ProService;
using e_shop.Services.Login;
using e_shop.Services.Order;
using e_shop.Storages.CredentialStorageBroker;
using e_shop.Brokers.Storages.ProductStorageBroker;

internal class Program
{
    static ILoginService loginService = new LoginService();
    static ILoggingBroker loggingBroker = new LoggingBroker();
    static IShippingService shippingService = new ShippingService();
    static IProductService productService = new ProductService();
    static IFileStorageBroker fileStorageBroker = new FileStorageBroker();
        
    private static void Main(string[] args)
    {

        bool checkTrueLoginAndPassword = false;
        bool retry = true;
        do
        {
            Console.Clear();
            ShowMenu();
            System.Console.Write("Choose >>> ");
            int myChoose = Convert.ToInt32(System.Console.ReadLine());
            Credential credential = new Credential();
            if (myChoose == 1)
            {
                System.Console.Clear();
                credential = CreateCredential();
                loginService.AddCredential(credential);
                loggingBroker.LogSucces("Credential added successfully!");
            }
            else 
            { 
                System.Console.Clear();
                credential = CreateCredential();
                if (fileStorageBroker.CheckUserLogin(credential))
                {
                    checkTrueLoginAndPassword = true;
                    loginService.CheckCredentialLogin(credential);
                    bool chooseElse = true;
                    do
                    {
                        Console.WriteLine("===== Let's Shopping =====");
                        productService.ShowAllProducts();
                        Console.Write("Choose >>> ");
                        int productId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("How many kilograms? >>> ");
                        double weight = Convert.ToDouble(Console.ReadLine()); 
                        Product product = new Product();
                        if (productId == 1)
                        {
                            product.Name = "Apple";
                            product.Price = 25000;
                            product.Weight = weight;
                        }
                        else if (productId == 2)
                        {
                            product.Name = "Banana";
                            product.Price = 20000;
                            product.Weight = weight;
                        }
                        else if (productId == 3)
                        {
                            product.Name = "Orange";
                            product.Price = 35000;
                            product.Weight = weight;
                        }
                        else if (productId == 4)
                        {
                            product.Name = "Kiwi";
                            product.Price = 30000;
                            product.Weight = weight;
                        }
                        else if (productId == 5)
                        {
                            product.Name = "Granate";
                            product.Price = 25000;
                            product.Weight = weight;
                        }
                        else
                        {
                            loggingBroker.LogError("No such product exists!");
                        }
                        if (productId > 0 && productId < 6)
                        {
                            loggingBroker.LogSucces("Product added Successfully ✔️");
                            productService.AddProductToCart(product);
                            Console.Write("Do you want to buy another product? [yes/no] >>> ");
                            if (Console.ReadLine() == "no")
                            {
                                chooseElse = false;
                            }
                        }
                        else
                            loggingBroker.LogError("This product does not exist, please select again.");

                    } while (chooseElse);

                    Console.WriteLine("How would you like to deliver the products?");
                    Console.WriteLine("1. Air\n2. Sea\n3.Ground");
                    Console.Write("Choose >>> ");
                    int shippingType = Convert.ToInt32(Console.ReadLine());
                    if (shippingType == 1)
                    {
                        Console.Clear();
                        Shipping shipping = new Shipping();
                        shipping.Type = "Air";
                        shipping.Cost = 100;
                        shipping.Date = null;
                        productService.CalculateProductCartWithShipping(shipping);
                    }
                    else if (shippingType == 2)
                    {
                        Console.Clear();
                        Shipping shipping = new Shipping();
                        shipping.Type = "Sea";
                        shipping.Cost = 120;
                        shipping.Date = null;
                        productService.CalculateProductCartWithShipping(shipping);
                    }
                    else if (shippingType == 3)
                    {
                        Console.Clear();
                        Shipping shipping = new Shipping();
                        shipping.Type = "Ground";
                        shipping.Cost = 70;
                        shipping.Date = null;
                        productService.CalculateProductCartWithShipping(shipping);
                    }
                }
                else
                {
                    Console.Clear();
                    loggingBroker.LogError("You entered the wrong login or password, please try again!");
                }
            }

            if (checkTrueLoginAndPassword == true)
            {
                Console.Write("Do you want to do online shopping again? [yes/no] >>> ");
                if (Console.ReadLine() == "no")
                    retry = false;
            }

        }while(retry);

        Console.Clear();
        loggingBroker.LogSucces("Thanks for your choice, Bye!");
    }

    private static void ShowMenu()
    {
        System.Console.WriteLine("\t===== Welcome to online shop! ======");
        System.Console.WriteLine("1. Sign Up");
        System.Console.WriteLine("2. Log In");
    }

    private static Credential CreateCredential()
    {
        Credential credential = new Credential();
        System.Console.Write("Enter your username >>> ");
        string? newUsername = System.Console.ReadLine();
        System.Console.Write("Enter your password >>> ");
        string? newPassword = System.Console.ReadLine();
        credential.UserName = newUsername;
        credential.Password = newPassword;
        return credential;
    }
}