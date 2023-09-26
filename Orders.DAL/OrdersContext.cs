using Microsoft.EntityFrameworkCore;

namespace Orders.DAL;

public partial class OrdersContext : DbContext
{
	private readonly string _connectionString;
	public OrdersContext(string connectionString)
	{
		_connectionString = connectionString;
	}

	public virtual DbSet<Customer> Customer { get; set; }

	public virtual DbSet<Order> Order { get; set; }

	public Order InsertOrder(int customerId, decimal quantity)
	{
		return this.Order.FromSqlRaw<Order>("EXEC Order_I {0}, {1}", customerId, quantity).AsEnumerable().Single();
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)=> optionsBuilder.UseSqlServer(_connectionString);

}
