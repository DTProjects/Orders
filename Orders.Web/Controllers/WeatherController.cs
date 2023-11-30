using Microsoft.AspNetCore.Mvc;
using Orders.Web.Models;
using System.Net;
using System.Net.Http;
using System.Text.Json;

namespace Orders.Web.Controllers
{
	public class WeatherController : Controller
	{
		public async Task<IActionResult> GetWeather()
		{
			HttpClient httpClient = new HttpClient();

			string url = "https://api.weather.gov/gridpoints/SGX/42,63/forecast";

			httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0");
			HttpResponseMessage response = await httpClient.GetAsync(url);
			WeatherModel model= await response.Content.ReadFromJsonAsync<WeatherModel>();

			return View("Weather", model);			
		}
	}
}
