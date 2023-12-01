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

        [Microsoft.AspNetCore.Mvc.Route("[controller]/Find/{id?}")]
        [HttpGet]
        public ActionResult<string> GetOrder(int id)
        {
            Order res = _repository.GetOrder(id);
            OrderModel model = new OrderModel(res);
            return model.OrderNumber;
        }

        [Microsoft.AspNetCore.Mvc.Route("[controller]/NewOrder")]
        [HttpPost]
        public ActionResult NewOrder([FromForm] OrderModel model) 
        {
            Order res = _repository.NewOrder(model);
            return Ok($"Order number {res.OrderNumber} successfully created");
        }

        [Microsoft.AspNetCore.Mvc.Route("[controller]/{id?}")]
        [HttpPut]
        public ActionResult UpdateOrder([FromForm] OrderModel model, [FromRoute] int id)
        {
            _repository.UpdateOrder(model);
            return Ok($"Order id {id} successfully updated");
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
