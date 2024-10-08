CREATE PROCEDURE CreateProduct
	@Name VARCHAR(100),
	@Price DECIMAL(10,2),
	@Category VARCHAR(50),
	@DateAdded DATE
AS
BEGIN
	INSERT INTO Product(Name, Price, Category, DateAdded)
	VALUES(@Name, @Price, @Category, @DateAdded);
END;
GO

CREATE PROCEDURE ReadProductByID
	@ProductID INT
AS
BEGIN
	SELECT * FROM Product
	WHERE ProductID = @ProductID;
END;
GO

CREATE PROCEDURE ReadProductByName
	@Name VARCHAR(100)
AS
BEGIN
	SELECT * FROM Product
	WHERE Name like '%' + @Name + '%';
END;
GO

CREATE PROCEDURE UpdateProduct
	@Name VARCHAR(100),
	@Price DECIMAL(10,2),
	@Category VARCHAR(50),
	@DateAdded DATE
AS
BEGIN
	UPDATE Product
	SET Name = @Name,
		Price = @Price,
		Category = @Category,
		DateAdded = @DateAdded;
END;
GO


CREATE PROCEDURE DeleteProduct
	@ProductID INT
AS
BEGIN
	DELETE FROM Product
	WHERE ProductID = @ProductID;
END;