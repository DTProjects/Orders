  CREATE Procedure dbo.Order_I  @CustomerId INT, @Quantity DECIMAL(9, 2)
   AS
   BEGIN
	   DECLARE @Id AS INT;

	   INSERT INTO [Order] (CustomerId, Quantity) VALUES (@CustomerId, @quantity)
	   SET @Id = SCOPE_IDENTITY()

	   UPDATE [Order] SET OrderNumber = CONCAT(@Id, '-', @CustomerId) WHERE Id = @Id

	   SELECT * FROM [Order] WHERE Id = @Id
   END