namespace Orders.DAL;

public partial class Order
{
    public int Id { get; set; }

    public string OrderNumber { get; set; } = null!;

    public int CustomerId { get; set; }

    public decimal Quantity { get; set; }

}
