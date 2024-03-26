using Microsoft.Extensions.Configuration;

namespace Orders.DAL
{
	public class OrdersRepositoryEF : IOrdersRepository
	{
		private readonly string _connectionString;

		public OrdersRepositoryEF(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("OrdersDb") ?? "";
		}


		public List<OrderItem> GetOrders()
		{
			using (OrdersContext entities = new OrdersContext(_connectionString))
			{
				var joinRes = from o in entities.Order
							  join c in entities.Customer on o.CustomerId equals c.Id
							  orderby o.Id
							  select new OrderItem
							  {
								  Id = o.Id,
								  OrderNumber = o.OrderNumber,
								  FirstName = c.FirstName,
								  LastName = c.LastName,
								  Quantity = o.Quantity
							  };

				return joinRes.ToList();
			}
		}

		public Order GetOrder(int orderId)
		{
			using (OrdersContext entities = new OrdersContext(_connectionString))
			{
				return entities.Order.Single(m => m.Id == orderId);
			}
		}

		public Order NewOrder(int customerId, decimal quantity)
		{
			using (OrdersContext entities = new OrdersContext(_connectionString))
			{
				return entities.InsertOrder(customerId, quantity);
			}
		}

		public void UpdateOrder(int orderId, decimal quantity)
		{
			using (OrdersContext entities = new OrdersContext(_connectionString))
			{
				Order? order = entities.Order.Find(orderId);
				if (order == null)
				{
					return;
				}

				order.Quantity = quantity;
				entities.SaveChanges();
			}
		}

		public void DeleteOrder(int orderId)
		{
			using (OrdersContext entities = new OrdersContext(_connectionString))
			{
				Order? order = entities.Order.Find(orderId);
				if (order == null)
				{
					return;
				}

				entities.Order.Remove(order);
				entities.SaveChanges();
			}
		}

		public List<Customer> GetCustomers()
		{
			using (OrdersContext entities = new OrdersContext(_connectionString))
			{
				return entities.Customer.ToList();
			}
		}

        public string GetCustomerName(int customerId)
        {
            using (OrdersContext entities = new OrdersContext(_connectionString))
            {
                Customer cust = entities.Customer.Single(c => c.Id == customerId);
                return (cust.FirstName + " " + cust.LastName);
            }
        }
    }
}


