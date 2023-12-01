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
        public ActionResult Edit(int id)
        {
            Order order = _repository.GetOrder(id);
            OrderModel model = new OrderModel(order);
            model.Customers = _repository.GetCustomers().Select(t => new CustomerModel(t));

            return View(model);
        }

        [HttpGet]
        public ActionResult CreateOrder()
        {
            OrderModel model = new OrderModel();
            model.Customers = _repository.GetCustomers().Select(t => new CustomerModel(t));

            return View("Add", model);
        }

        [HttpGet]
        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add()
        {
            OrderModel model = new OrderModel();
            model.Customers = _repository.GetCustomers().Select(t => new CustomerModel(t));

            return View("Add", model);
        }

        [HttpPost]
        public ActionResult Save(OrderModel model)
        {
            Order newInfo = _repository.NewOrder(model);

            return RedirectToAction("Index", "Order", new {newOrderNum = newInfo.OrderNumber.ToString() });
		}

        [HttpPost]
        public ActionResult Update(OrderModel model)
        {
            _repository.UpdateOrder(model);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int OrderId)
        {
            _repository.DeleteOrder(OrderId);

            return Json(new { RedirectURL = "/Order/Index" });
        }
    }
}