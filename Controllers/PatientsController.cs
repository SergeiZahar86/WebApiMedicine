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
        private EntityContext entityContext;
        private readonly ILogger<PatientsController> _logger;
        public PatientsController(EntityContext context, ILogger<PatientsController> logger) 
        { 
            entityContext = context;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Patients> Get()
        {
            return entityContext.Patients.ToArray();
        }
    }
}
