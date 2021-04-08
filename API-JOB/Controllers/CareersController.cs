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
    public class CareersController : ControllerBase
    {
        private readonly EmploymentDBContext _context;

        public CareersController(EmploymentDBContext context)
        {
            _context = context;
        }

        // GET: api/Careers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Careers>>> GetCareers()
        {
            return await _context.Careers.ToListAsync();
        }

        // GET: api/Careers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Careers>> GetCareers(int id)
        {
            var careers = await _context.Careers.FindAsync(id);

            if (careers == null)
            {
                return NotFound();
            }

            return careers;
        }

        // PUT: api/Careers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCareers(int id, Careers careers)
        {
            if (id != careers.CareerId)
            {
                return BadRequest();
            }

            _context.Entry(careers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CareersExists(id))
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

        // POST: api/Careers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Careers>> PostCareers(Careers careers)
        {
            _context.Careers.Add(careers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCareers", new { id = careers.CareerId }, careers);
        }

        // DELETE: api/Careers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Careers>> DeleteCareers(int id)
        {
            var careers = await _context.Careers.FindAsync(id);
            if (careers == null)
            {
                return NotFound();
            }

            _context.Careers.Remove(careers);
            await _context.SaveChangesAsync();

            return careers;
        }

        private bool CareersExists(int id)
        {
            return _context.Careers.Any(e => e.CareerId == id);
        }
    }
}
