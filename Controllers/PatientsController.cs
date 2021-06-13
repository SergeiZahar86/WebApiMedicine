using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiMedicine.Models;

namespace WebApiMedicine.Controllers
{
    [Route("api/[controller]")]
    public class PatientsController : Controller
    {

        private readonly ILogger<PatientsController> _logger;

        public PatientsController(ILogger<PatientsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Patients> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Patients
            {
                Id = 1,
                Age = 33
                /*Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]*/
            })
            .ToArray();
        }
    }
}
