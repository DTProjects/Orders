using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.DAL
{
	public class OrdersRepositoryEF
	{
		public List<Order> GetOrders()
		{
			using (OrdersEntities entities = new OrdersEntities())
			{
				return entities.Orders.ToList();
			}
		}

		public Order GetOrder(int orderId)
		{
			using (OrdersEntities entities = new OrdersEntities())
			{
				return entities.Orders.Single(m => m.Id == orderId);
			}
		}

		public void UpdateOrder(int orderId, decimal quantity)
		{
			using (OrdersEntities entities = new OrdersEntities())
			{
				Order order = entities.Orders.Find(orderId);
				order.Quantity = quantity;
				entities.SaveChanges();
			}
		}

		public void DeleteOrder(int orderId)
		{
			using (OrdersEntities entities = new OrdersEntities())
			{
				Order target = entities.Orders.Find(orderId);
				entities.Orders.Remove(target);
				entities.SaveChanges();
			}
		}
	}
}

