namespace Practice4.Entity.DTO
{
    public class DailySale
    {
        public DateTime Date { get; set; }
        public decimal TotalSale { get; set; }

        public DailySale(DateTime date, decimal totalSale)
        {
            Date = date;
            TotalSale = totalSale;
        }
    }
}
