  CREATE Procedure [dbo].[Order_I]  @CustomerId INT, @Quantity DECIMAL(9, 2)
   AS
   BEGIN
	   DECLARE @Id AS INT;

	   INSERT INTO [Order] (CustomerId, OrderNumber, Quantity) VALUES (@CustomerId, '', @Quantity)
	   SET @Id = SCOPE_IDENTITY()

	   UPDATE [Order] SET OrderNumber = CONCAT(@Id, '-', @CustomerId) WHERE Id = @Id

	   SELECT * FROM [Order] WHERE Id = @Id
   END