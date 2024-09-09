using Practice4.Entity;
using Practice4.Entity.DTO;
using Practice4.Repository;

namespace Practice4.Service
{
    public class DatabaseService
    {
        private readonly int currentMonth;
        private readonly int currentYear;
        private readonly DatabaseContext context;

        public DatabaseService(DatabaseContext context)
        {
            currentMonth = DateTime.Now.Month;
            currentYear = DateTime.Now.Year;
            this.context = context;
        }

        public List<Product> GetAllProducts()
        {
            return context.Product.ToList();
        }

        public bool CreateProduct(string name, decimal price, string category)
        {
            context.Add(new Product
            {
                Name = name,
                Price = price,
                Category = category,
                DateAdded = DateTime.Now
            });

            return context.SaveChanges() > 0;
        }

        public List<Product> GetProductByIdOrName(string query)
        {
            return context.Product
                .Where(product => product.Name == query
                        || product.ProductId.ToString() == query)
                .ToList();
        }

        public List<DailySale> GetDailySales()
        {
            return context.Sale
                .GroupBy(sale => sale.SaleDate)
                .Select(group => new DailySale(group.Key,
                        group.Sum(sale => sale.SalePrice * sale.Quantity)))
                .OrderByDescending(group => group.TotalSale)
                .ToList();
        }

        public List<SaleDetails> GetSaleDetails()
        {
            return context.Sale
                .Where(sale => sale.SaleDate.Month == currentMonth
                        && sale.SaleDate.Year == currentYear)
                .Join(context.Product,
                    sale => sale.ProductID,
                    product => product.ProductId,
                    (sale, product) => new SaleDetails(sale.SaleID, product.Name,
                            sale.Quantity, sale.SalePrice, sale.SaleDate))
                .ToList();
        }

        public List<Product> GetProductsWithNoSales()
        {
            return context.Product
                .GroupJoin(context.Sale,
                    product => product.ProductId,
                    sale => sale.ProductID,
                    (product, sale) => new { product, sale })
                .SelectMany(ps => ps.sale.DefaultIfEmpty(),
                    (ps, sale) => new { ps.product, sale })
                .Where(ps => ps.sale == null)
                .Select(ps => ps.product)
                .ToList();
        }

        public List<ProductSale> GetProductSales()
        {
            return context.Sale
                .Where(sale => sale.SaleDate.Month == currentMonth
                        && sale.SaleDate.Year == currentYear)
                .GroupBy(sale => sale.ProductID)
                .Select(group => new
                {
                    ProductId = group.Key,
                    TotalSale = group.Sum(sale => sale.SalePrice * sale.Quantity),
                })
                .Join(context.Product,
                    group => group.ProductId,
                    product => product.ProductId,
                    (group, product) => new ProductSale(product.Name, group.TotalSale))
                .ToList();
        }
    }
}
