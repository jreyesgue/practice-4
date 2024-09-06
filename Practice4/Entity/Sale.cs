namespace Practice4.Entity
{
    public class Sale
    {
        public int SaleID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal SalePrice { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
