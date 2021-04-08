using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_JOB.Models;

namespace API_JOB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraduateplusController : ControllerBase
    {
        private readonly EmploymentDBContext _context;

        public GraduateplusController(EmploymentDBContext context)
        {
            _context = context;
        }

        // GET: api/Graduateplus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Graduateplus>>> GetGraduateplus()
        {
            return await _context.Graduateplus.ToListAsync();
        }

        // GET: api/Graduateplus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Graduateplus>> GetGraduateplus(int id)
        {
            var graduateplus = await _context.Graduateplus.FindAsync(id);

            if (graduateplus == null)
            {
                return NotFound();
            }

            return graduateplus;
        }

        // PUT: api/Graduateplus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGraduateplus(int id, Graduateplus graduateplus)
        {
            if (id != graduateplus.GradId)
            {
                return BadRequest();
            }

            _context.Entry(graduateplus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GraduateplusExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Graduateplus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Graduateplus>> PostGraduateplus(Graduateplus graduateplus)
        {
            _context.Graduateplus.Add(graduateplus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGraduateplus", new { id = graduateplus.GradId }, graduateplus);
        }

        // DELETE: api/Graduateplus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Graduateplus>> DeleteGraduateplus(int id)
        {
            var graduateplus = await _context.Graduateplus.FindAsync(id);
            if (graduateplus == null)
            {
                return NotFound();
            }

            _context.Graduateplus.Remove(graduateplus);
            await _context.SaveChangesAsync();

            return graduateplus;
        }

        private bool GraduateplusExists(int id)
        {
            return _context.Graduateplus.Any(e => e.GradId == id);
        }
    }
}
