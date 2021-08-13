using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CoCAppAPI.Controllers
{
    public class SaveRequest
    {
        public string Title { get; set; }
        public List<string> Images { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public IActionResult Save(SaveRequest model)
        {
            string saveUrl = "D:/Dokumenty/zlecenia/aukcje/zdjecia/"+model.Title+"/";
            bool exists = System.IO.Directory.Exists(saveUrl);

            if (!exists)
                System.IO.Directory.CreateDirectory(saveUrl);

            using (WebClient client = new WebClient())
            {
                for(int i=0;i<model.Images.Count;i++)
                {
                    client.DownloadFile(new Uri(model.Images[i]), saveUrl + i.ToString() + ".jpg");
                }
                //client.DownloadFile(new)
            }
            return Ok();
        }
    }
}
