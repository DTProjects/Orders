using Orders.DAL;
using Orders.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Orders.Web.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult Index()
        {
            OrdersRepositoryEF entities = new OrdersRepositoryEF();
            IEnumerable<OrderModel> model = entities.GetOrders().Select(o => new OrderModel(o)); 

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            OrdersRepositoryEF entities = new OrdersRepositoryEF();
            Order order = entities.GetOrder(id);
            OrderModel model = new OrderModel(order);
            
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Customers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(OrderModel model)
        {
            OrdersRepositoryEF entities = new OrdersRepositoryEF();
            entities.UpdateOrder(model.Id, model.Quantity);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int OrderId)
        {
            OrdersRepositoryEF entities = new OrdersRepositoryEF();
            entities.DeleteOrder(OrderId);

            return Json(new { RedirectURL = "/Order/Index" });
        }
    }
}