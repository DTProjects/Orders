using Orders.DAL;
using System.Collections.Generic;

namespace Orders.Web.Models
{
	public class OrderModel
	{
		public int Id { get; set; }
		public string OrderNumber { get; set; }
		public int CustomerId { get; set; }
		public decimal Quantity { get; set; }

		public IEnumerable<CustomerModel> Customers {get; set;}
		public OrderModel()
		{
		}
		public OrderModel(Order order)
		{
			Id = order.Id;
			OrderNumber = order.OrderNumber;
			CustomerId = order.CustomerId;
			Quantity = order.Quantity;
		}
	}
}