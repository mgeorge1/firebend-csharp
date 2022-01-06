using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Data;

namespace SrDevTest.Controllers
{
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
        [Route("")]
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

        [HttpGet]
        [Route("{id:int}")]//I know the stuff below this point makes no sense; I was just playing around in this file
        public IEnumerable<WeatherForecast> GetCrazyForecast(int id)
        {
            //return new List<WeatherForecast> {
            //new WeatherForecast{
            //    Date = new DateTime(1998, 05, 11),
            //    TemperatureC = -40,
            //    Summary = "It was a really cold day"
            //}};

            return Enumerable.Range(1,5).Select(index => new WeatherForecast
            {
                Date = new DateTime(1998, 05, 11),
                    TemperatureC = id,
                    Summary = "It is cold!"
            })
    .ToArray();
        }

        [HttpGet]
        [Route("{range:int},{temperature:int}")]
        public IEnumerable<WeatherForecast> SearchForecasts(int range, int temperature)
        {
            //return new List<WeatherForecast> {
            //new WeatherForecast{
            //    Date = new DateTime(1998, 05, 11),
            //    TemperatureC = -40,
            //    Summary = "It was a really cold day"
            //}};
            
            return Enumerable.Range(1, range).Select(index => new WeatherForecast
            {
                Date = new DateTime(1998, 05, 11),
                TemperatureC = temperature,
                Summary = "It is cold!"
            })
    .ToArray();
            try
            {
                using (var context = new AdventureWorks2019Context())
                {
                    var productCategory = new ProductCategory
                    {
                        ProductCategoryId = 11111,
                        Name = "Maggie's test product",
                        ModifiedDate = DateTime.Now
                    };

                    context.ProductCategories.Add(productCategory);
                    context.SaveChanges();
                }
            }catch(Exception ex)
            {

            }
        }
    }
}