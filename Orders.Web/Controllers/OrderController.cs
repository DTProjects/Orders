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

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Customers()
        {
            return View();
        }
    }
}