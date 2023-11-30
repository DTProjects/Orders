namespace Orders.Web.Models
{
	public class WeatherModel
	{
		public string type { get; set; }

		public WeatherProperties properties { get; set; }
	}

	public class WeatherProperties
	{
		public string updated { get; set; }
		public string units { get; set; }
		public string forecastGenerator { get; set; }
		public string generatedAt { get; set; }
		public string updateTime { get; set; }
		//public string validTimes { get; set; }
		//public string elevation { get; set; }
		public WeatherPeriod[] periods { get; set; }
	}

	public class WeatherPeriod
	{
		public int number { get; set; }
		public string name { get; set; }
		public string startTime { get; set; }
		public string endTime { get; set; }
		public bool isDaytime { get; set; }
		public int temperature { get; set; }
		public string temperatureUnit { get; set; }
		//public string temperatureTrend { get; set; }
		//public string probabilityOfPrecipitation { get; set; }
		//public string dewpoint { get; set; }
		//public string relativeHumidity { get; set; }
		public string windSpeed { get; set; }
		public string windDirection { get; set; }
		public string icon { get; set; }
		public string shortForecast { get; set; }
		public string detailedForecast { get; set; }
	}
}
