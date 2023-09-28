using Microsoft.AspNetCore.Mvc;
using Orders.DAL;
using Orders.Web.Models;

namespace Orders.Web.Controllers
{
	public class CustomerController : Controller
	{
		private readonly IOrdersRepository _repository;
		public CustomerController(IOrdersRepository repository)
		{
			_repository = repository;
		}
		[HttpGet]
		public IActionResult Customers()
		{
			IEnumerable<CustomerModel> model = _repository.GetCustomers().Select(c=>new CustomerModel(c));
			return View(model);
		}
	}
}
