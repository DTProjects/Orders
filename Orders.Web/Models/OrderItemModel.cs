using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orders.DAL;

namespace Orders.Web.Models
{
	public class OrderItemModel
	{
		public int Id { get; set; }
		public string OrderNumber { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public decimal Quantity { get; set; }

		public OrderItemModel()
		{
		}

		public OrderItemModel(OrderItem orderItem)
		{
			Id = orderItem.Id;
			OrderNumber = orderItem.OrderNumber;
			FirstName = orderItem.FirstName;
			LastName = orderItem.LastName;
			Quantity = orderItem.Quantity;
		}
	}
}