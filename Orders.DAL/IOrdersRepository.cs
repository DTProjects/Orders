namespace Orders.DAL
{
	public interface IOrdersRepository
    {
        List<OrderItem> GetOrders();

        Order GetOrder(int orderId);

        Order NewOrder(Order order);

        void UpdateOrder(Order order);

        void DeleteOrder(int orderId);


        List<Customer> GetCustomers();
    }
}
