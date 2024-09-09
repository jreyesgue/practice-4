using Practice4.ConsoleUtils;
using Practice4.Repository;
using Practice4.Service;

namespace Practice4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DatabaseContext())
            {
                bool finish = false;
                var service = new DatabaseService(context);

                do
                {
                    MenuPlayer.DisplayMenu();

                    switch (ConsoleReader.GetOption())
                    {
                        case 1:
                            service.GetAllProducts().ForEach(ConsolePrinter.PrintProduct);
                            break;
                        case 2:
                            string productName = ConsoleReader.GetStringParam("\nEnter the product name: ");
                            decimal productPrice = ConsoleReader.GetDecimalParam("Enter the product price: ");
                            string productCategory = ConsoleReader.GetStringParam("Enter the product category: ");

                            if (service.CreateProduct(productName, productPrice, productCategory))
                            {
                                Console.WriteLine("\nProduct Added.");
                            }
                            break;
                        case 3:
                            string query = ConsoleReader.GetStringParam("\nEnter the product name or id: ");

                            service.GetProductByIdOrName(query).ForEach(ConsolePrinter.PrintProduct);
                            break;
                        case 4:
                            service.GetDailySales().ForEach(ConsolePrinter.PrintDailySale);
                            break;
                        case 5:
                            service.GetSaleDetails().ForEach(ConsolePrinter.PrintSaleDetails);
                            break;
                        case 6:
                            service.GetProductsWithNoSales().ForEach(ConsolePrinter.PrintProduct);
                            break;
                        case 7:
                            service.GetProductSales().ForEach(ConsolePrinter.PrintProductSale);
                            break;
                        case 8:
                            Console.WriteLine("\nGoodbye :)");
                            finish = true;
                            break;
                        default:
                            Console.WriteLine("\nInvalid option. Try Again.");
                            break;
                    }
                } while (!finish);
            }

        }
    }
}
