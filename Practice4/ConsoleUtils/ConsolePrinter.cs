using Practice4.Entity;
using Practice4.Entity.DTO;

namespace Practice4.ConsoleUtils
{
    public static class ConsolePrinter
    {
        public static void PrintProduct(Product product)
        {
            Console.WriteLine($"\n--- Product {product.ProductId} ---");
            Console.WriteLine($"Name: {product.Name}");
            Console.WriteLine($"Price: {product.Price}");
            Console.WriteLine($"Category: {product.Category}");
            Console.WriteLine($"Date Added: {product.DateAdded}");
        }

        public static void PrintDailySale(DailySale sale)
        {
            Console.WriteLine($"\nDate: {sale.Date}, Total Sale: {sale.TotalSale}");
        }

        public static void PrintSaleDetails(SaleDetails sale)
        {
            Console.WriteLine($"\nSale ID: {sale.SaleID}, Product: {sale.ProductName}, " +
                $"Quantity: {sale.Quantity}, Price: {sale.SalePrice}, Date: {sale.SaleDate}");
        }

        public static void PrintProductSale(ProductSale sale)
        {
            Console.WriteLine($"\nProduct: {sale.ProductName}, Total Sale: {sale.TotalSale}");
        }
    }
}
