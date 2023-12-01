using Orders.DAL;

namespace Orders.Web.Models
{
	public class OrderModel: Order
	{
		public IEnumerable<CustomerModel> Customers {get; set;}
		public OrderModel()
		{
			OrderNumber = "";
			Customers = Enumerable.Empty<CustomerModel>();
		}
		public OrderModel(Order order)
			: this()
		{
			Id = order.Id;
			OrderNumber = order.OrderNumber;
			CustomerId = order.CustomerId;
			Quantity = order.Quantity;
		}
	}
}