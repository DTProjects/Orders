namespace Orders.DAL
{
	public class OrderItem
	{
		public int Id { get; set; }
		public string OrderNumber { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public decimal Quantity { get; set; }
	}
}