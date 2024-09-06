CREATE TABLE #ProductStatus (
	ProductID INT,
	Name VARCHAR(100),
	Status VARCHAR(100)
);

INSERT INTO #ProductStatus
SELECT p.ProductID,
	Name,
    CASE WHEN SUM(Quantity) IS NULL
		THEN 'Unsold product'
        ELSE 'Number of sales: ' + CAST(SUM(Quantity) AS VARCHAR)
    END AS StatusText
FROM Product p
LEFT JOIN Sale s ON p.ProductID = s.ProductID
GROUP BY p.ProductID, p.Name;

SELECT * FROM #ProductStatus;
GO

SELECT PurchaseID, pu.ProductID, Name AS ProductName, Quantity , PurchasePrice, PurchaseDate
FROM Purchase pu
JOIN Product pr ON pr.ProductID = pu.ProductID
WHERE Name LIKE 'L%';