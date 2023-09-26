namespace Orders.DAL
{
	public interface IOrdersRepository
    {
        List<OrderItem> GetOrders();

        Order GetOrder(int orderId);

        Order NewOrder(int customerId, decimal quantity);

        void UpdateOrder(int orderId, decimal quantity);

        void DeleteOrder(int orderId);


        List<Customer> GetCustomers();
    }
}
