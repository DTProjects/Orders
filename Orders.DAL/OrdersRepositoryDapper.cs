﻿using Dapper;
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
				return con.Query<OrderItem>("SELECT o.Id, o.OrderNumber,c.FirstName,c.LastName,o.quantity FROM [Order] o LEFT JOIN [Customer] c ON o.CustomerId = c.Id ORDER BY o.Id").ToList();
			}
		}

		public Order GetOrder(int orderId)
		{
			using (SqlConnection con = new SqlConnection(_connectString))
			{
				return con.QuerySingle<Order>("SELECT * FROM [Order] WHERE Id = @OrderId", new { OrderId = orderId });
			}
		}

		public Order NewOrder(Order order)
		{			
			using (SqlConnection con = new SqlConnection(_connectString))
			{
				return con.QuerySingle<Order>("EXEC Order_I @CustomerId, @Quantity", order);				
			}
		}
		public void UpdateOrder(Order order)
		{
			string sql = @"UPDATE [Order] SET Quantity=@Quantity WHERE Id=@Id";
			using (SqlConnection con = new SqlConnection(_connectString))
			{
				con.Execute(sql, order);
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
