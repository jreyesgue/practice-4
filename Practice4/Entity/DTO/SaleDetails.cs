namespace Practice4.Entity.DTO
{
    public class SaleDetails
    {
        public int SaleID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal SalePrice { get; set; }
        public DateTime SaleDate { get; set; }

        public SaleDetails(int saleID, string productName, int quantity,
            decimal salePrice, DateTime saleDate)
        {
            SaleID = saleID;
            ProductName = productName;
            Quantity = quantity;
            SalePrice = salePrice;
            SaleDate = saleDate;
        }
    }
}
