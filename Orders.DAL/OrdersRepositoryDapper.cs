using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Orders.DAL
{
	public class OrdersRepositoryDapper : IOrdersRepository
	{
		private readonly string _connectString;

		public OrdersRepositoryDapper(IConfiguration configuration)
		{
			_connectString = configuration.GetConnectionString("OrdersDb") ?? "";
		}

		public List<OrderItem> GetOrders()
		{
			using (SqlConnection con = new SqlConnection(_connectString))
			{				
				return con.Query<OrderItem>("SELECT o.Id, o.OrderNumber,c.FirstName,c.LastName,o.quantity FROM [Order] o LEFT JOIN [Customer] c ON o.CustomerId = c.Id").ToList();
			}
		}

		public Order GetOrder(int orderId)
		{
			using (SqlConnection con = new SqlConnection(_connectString))
			{
				return con.QuerySingle<Order>("SELECT * FROM [Order] WHERE Id = @OrderId", new { OrderId = orderId });
			}
		}

		public Order NewOrder(int customerId, decimal quantity)
		{			
			using (SqlConnection con = new SqlConnection(_connectString))
			{
				Order ord = con.QuerySingle<Order>("EXEC Order_I @CustomerId, @Quantity", new
				{
					CustomerId = customerId,
					Quantity = quantity
				});

				return ord;
			}
		}
		public void UpdateOrder(int orderId, decimal quantity)
		{
			string sql = @"UPDATE [Order] SET Quantity=@Quantity WHERE Id=@OrderId";
			using (SqlConnection con = new SqlConnection(_connectString))
			{
				con.Execute(sql, new { Quantity = quantity, OrderId = orderId });
			}
		}

		public void DeleteOrder(int orderId)
		{
			string sql = @"DELETE FROM [Order] WHERE Id=@OrderId";
			using (SqlConnection con = new SqlConnection(_connectString))
			{
				con.Execute(sql, new { OrderId = orderId });
			}
		}

		public List<Customer> GetCustomers()
		{
			using (SqlConnection con = new SqlConnection(_connectString))
			{
				return con.Query<Customer>("SELECT * FROM [Customer]").ToList();
			}
		}
	}
}
