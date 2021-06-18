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
    [ApiController]
    public class VisitsController : ControllerBase
    {
        private EntityContext entityContext;
        private readonly ILogger<PatientsController> _logger;
        public VisitsController(EntityContext context, ILogger<PatientsController> logger)
        {
            entityContext = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visits>>> Get()
        {
            return await entityContext.Visits.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Visits>>> Get(int id)
        {
            var visits = await (from Visits in entityContext.Visits
                             where Visits.PatientsInfoKey == id select Visits).ToListAsync();
            if (visits == null)
                return NotFound();
            return new ObjectResult(visits);
        }

        /*[HttpPost]
        public async Task<ActionResult<Visits>> Post([FromBody] Visits visits)
        {
            if (visits == null)
                return BadRequest();
            entityContext.Visits.Add(visits);
            await entityContext.SaveChangesAsync();
            return Ok(visits);
        }*/
        [HttpPost("{id}")]
        public async Task<ActionResult<Visits>> Post(int id, [FromBody] Visits visits)
        {
            if (visits == null)
                return BadRequest();
            Visits vis = new Visits()
            {
                Date = visits.Date,
                Type = visits.Type,
                Diagnosis = visits.Diagnosis,
                PatientsInfoKey = id
            };
            entityContext.Visits.Add(vis);
            await entityContext.SaveChangesAsync();
            return Ok(vis);
        }


        /* [HttpPut]
         public async Task<ActionResult<Visits>> Put([FromBody] Visits visits)
         {
             if (visits == null)
                 return BadRequest();
             if (!entityContext.Visits.Any(x => x.Id == visits.Id))
                 return NotFound();
             entityContext.Update(visits);
             await entityContext.SaveChangesAsync();
             return Ok(visits);
         }*/
        [HttpPut("{id}")]
        public async Task<ActionResult<Visits>> Put(int id, [FromBody] Visits visits)
        {
            if (visits == null)
                return BadRequest();
            if (!entityContext.Visits.Any(x => x.Id == id))
                return NotFound();
            Visits vis = new Visits()
            {
                Id = id,
                Date = visits.Date,
                Type = visits.Type,
                Diagnosis = visits.Diagnosis,
                PatientsInfoKey = visits.PatientsInfoKey
            };
            entityContext.Update(vis);
            await entityContext.SaveChangesAsync();
            return Ok(vis);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Visits>> Delete(int id)
        {
            Visits visits = entityContext.Visits.FirstOrDefault(x => x.Id == id);
            if (visits == null)
                return NotFound();
            entityContext.Visits.Remove(visits);
            await entityContext.SaveChangesAsync();
            return Ok(visits);
        }
    }
}
