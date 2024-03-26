using Microsoft.AspNetCore.Mvc;
using Orders.DAL;
using Orders.Web.Models;

namespace Orders.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrdersRepository _repository;
        public OrderController(IOrdersRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult Index(string? newOrderNum)
        {
            OrderItemModel model = new OrderItemModel();
            model.OrderItems = _repository.GetOrders().Select(t => new OrderItemModel(t));

            if (newOrderNum != null)
            {
                model.NewOrderNum = newOrderNum;
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult CreateOrder()
        {
            OrderModel model = new OrderModel();
            model.Customers = _repository.GetCustomers().Select(t => new CustomerModel(t));
            model.IsEdit = false;

            return View("EditOrder", model);
        }

        [HttpGet]
        public ActionResult UpdateOrder(int id)
        {
            Order order = _repository.GetOrder(id);
            OrderModel model = new OrderModel(order);
            model.CustomerName = _repository.GetCustomerName(model.CustomerId);
            model.IsEdit = true;

            return View("EditOrder", model);

        }

        [HttpPost]
        public ActionResult SaveChanges(OrderModel model)
        {
            if (model.IsEdit)
            {
                _repository.UpdateOrder(model.Id, model.Quantity);

                return RedirectToAction("Index");
            }
            else
            {
                Order newInfo = _repository.NewOrder(model.CustomerId, model.Quantity);

                return RedirectToAction("Index", "Order", new { newOrderNum = newInfo.OrderNumber.ToString() });
            }
        }

        [HttpPost]
        public ActionResult Delete(int OrderId)
        {
            _repository.DeleteOrder(OrderId);

            return Json(new { RedirectURL = "/Order/Index" });
        }

        [HttpGet]
        public ActionResult About()
        {
            return View();
        }
    }
}