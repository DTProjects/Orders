using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Orders.DAL;
using Orders.Web.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Orders.Web.Controllers
{
    [ApiController]
    public class RestController : ControllerBase
    {
        private readonly IOrdersRepository _repository;

        public RestController(IOrdersRepository repository) 
        {
            _repository = repository;
        }

        [Microsoft.AspNetCore.Mvc.Route("[controller]/{id?}")]
        [HttpGet]
        public ActionResult<string> GetOrder(int id)
        {
            Order res = _repository.GetOrder(id);
            OrderModel model = new OrderModel(res);
            return model.OrderNumber;
        }

        [Microsoft.AspNetCore.Mvc.Route("[controller]/NewOrder")]
        [HttpPost]
        public ActionResult CreateOrder([FromBody] Order order) 
        {
            Order res = _repository.NewOrder(order.CustomerId, order.Quantity);
            return Ok($"Order id {res.OrderNumber} successfully created");
        }

        [Microsoft.AspNetCore.Mvc.Route("[controller]/{id?}")]
        [HttpDelete]
        public ActionResult DeleteOrder(int id) 
        {
            _repository.DeleteOrder(id);

            return Ok($"Order id {id} successfully deleted");
        }
    }
}
