namespace Practice4.Entity.DTO
{
    public class ProductSale
    {
        public string ProductName { get; set; }
        public decimal TotalSale { get; set; }

        public ProductSale(string productName, decimal totalSale)
        {
            ProductName = productName;
            TotalSale = totalSale;
        }
    }
}
