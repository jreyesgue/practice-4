CREATE VIEW ProductTransactions AS
SELECT 'Sale' AS TransactionType,
	SaleID AS TransactionID,
	p.ProductID,
	Quantity,
	SaleDate AS TransactionDate,
	Name AS ProductName,
	Category AS ProductCategory,
	SalePrice AS TransactionPrice
FROM Sale s
JOIN Product p ON p.ProductID = s.ProductID
UNION ALL
SELECT 'Purchase' AS TransactionType,
	PurchaseID AS TransactionID,
	pr.ProductID,
	Quantity,
	PurchaseDate AS TransactionDate,
	Name AS ProductName,
	Category AS ProductCategory,
	PurchasePrice AS TransactionPrice
FROM Purchase pu
JOIN Product pr ON pr.ProductID = pu.ProductID;
GO

CREATE VIEW ProductStatistics AS
SELECT Category,
    YEAR(SaleDate) AS Year,
    DATEPART(WEEK, SaleDate) AS Week,
    FORMAT(AVG(SalePrice), 'C') AS AverageSalePrice,
	FORMAT(MAX(SalePrice), 'C') AS MaxSalePrice,
	FORMAT(MIN(SalePrice), 'C') AS MinSalePrice
FROM Sale s
JOIN Product p ON p.ProductID = s.ProductID
GROUP BY Category, YEAR(SaleDate), DATEPART(WEEK, SaleDate)
GO