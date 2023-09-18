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
	}
}

