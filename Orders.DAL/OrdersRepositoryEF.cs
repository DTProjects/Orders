using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Orders.DAL
{
	public class OrdersRepositoryEF : IOrdersRepository
	{
		private readonly string _connectionString;

		public OrdersRepositoryEF()
		{
			string cn = ConfigurationManager.ConnectionStrings["OrdersDb"].ConnectionString;
			//EntityConnectionStringBuilder cnBuilder = new EntityConnectionStringBuilder();
			//cnBuilder.Provider = "System.Data.SqlClient";
			//cnBuilder.ProviderConnectionString = cn;
			//cnBuilder.Metadata = "res://*";

			SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(cn);

			_connectionString = $"metadata = res://*/OrdersModel.csdl|res://*/OrdersModel.ssdl|res://*/OrdersModel.msl;provider=System.Data.SqlClient;provider connection string=\"data source={sb.DataSource};initial catalog={sb.InitialCatalog};persist security info=True;user id={sb.UserID};password={sb.Password};MultipleActiveResultSets=True;App=EntityFramework\"";
		}


		public List<OrderItem> GetOrders()
		{
			using (OrdersEntities entities = new OrdersEntities(_connectionString))
			{
				var joinRes = from o in entities.Orders
				 join c in entities.Customers on o.CustomerId equals c.Id
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
			using (OrdersEntities entities = new OrdersEntities(_connectionString))
			{
				return entities.Orders.Single(m => m.Id == orderId);
			}
		}

		public Order NewOrder(int customerId, decimal quantity)
		{
			using (OrdersEntities entities = new OrdersEntities(_connectionString))
			{
				return entities.Order_I(customerId, quantity).Single();
			}
		}

		public void UpdateOrder(int orderId, decimal quantity)
		{
			using (OrdersEntities entities = new OrdersEntities(_connectionString))
			{
				Order order = entities.Orders.Find(orderId);
				order.Quantity = quantity;
				entities.SaveChanges();
			}
		}

		public void DeleteOrder(int orderId)
		{
			using (OrdersEntities entities = new OrdersEntities(_connectionString))
			{
				Order target = entities.Orders.Find(orderId);
				entities.Orders.Remove(target);
				entities.SaveChanges();
			}
		}

		public List<Customer> GetCustomers()
		{
			using (OrdersEntities entities = new OrdersEntities(_connectionString))
			{
				return entities.Customers.ToList();
			}
		}
	}
}


