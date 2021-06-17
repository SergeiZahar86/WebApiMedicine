using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        public async Task<ActionResult<IEnumerable<Patients>>> Get()
        {
            return await entityContext.Patients.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patients>> Get(int id)
        {
            Patients patients = await entityContext.Patients.FirstOrDefaultAsync(x => x.Id == id);
            if (patients == null)
                return NotFound();
            return new ObjectResult(patients);
        }

        [HttpPost]
        public async Task<ActionResult<Patients>> Post([FromBody] Patients patients)
        {
            if (patients == null)
                return BadRequest();
            entityContext.Patients.Add(patients);
            await entityContext.SaveChangesAsync();
            return Ok(patients);
        }

        /*[HttpPut]
        public async Task<ActionResult<Patients>> Put([FromBody] Patients patients)
        {
            if (patients == null)
                return BadRequest();
            if (!entityContext.Patients.Any(x => x.Id == patients.Id))
                return NotFound();
            entityContext.Update(patients);
            await entityContext.SaveChangesAsync();
            return Ok(patients);
        }*/
        [HttpPut("{id}")]
        public async Task<ActionResult<Patients>> Put(int id, [FromBody] Patients patients)
        {
            if (patients == null)
                return BadRequest();
            if (!entityContext.Patients.Any(x => x.Id == id))
                return NotFound();
            Patients pat = new Patients()
            {
                Id = id,
                Surname = patients.Surname,
                Name = patients.Name,
                Middle_name = patients.Middle_name,
                Address = patients.Address,
                Gender = patients.Gender,
                PhoneNumber = patients.PhoneNumber,
                Age = patients.Age,
                Birth = patients.Birth
            };
            entityContext.Update(pat);
            await entityContext.SaveChangesAsync();
            return Ok(pat);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Patients>> Delete(int id)
        {
            Patients patients = entityContext.Patients.FirstOrDefault(x => x.Id == id);
            if (patients == null)
                return NotFound();
            entityContext.Patients.Remove(patients);
            await entityContext.SaveChangesAsync();
            return Ok(patients);
        }
    }
}
