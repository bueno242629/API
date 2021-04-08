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
    public class ApplyjobsController : ControllerBase
    {
        private readonly EmploymentDBContext _context;

        public ApplyjobsController(EmploymentDBContext context)
        {
            _context = context;
        }

        // GET: api/Applyjobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Applyjob>>> GetApplyjob()
        {
            return await _context.Applyjob.ToListAsync();
        }

        // GET: api/Applyjobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Applyjob>> GetApplyjob(int id)
        {
            var applyjob = await _context.Applyjob.FindAsync(id);

            if (applyjob == null)
            {
                return NotFound();
            }

            return applyjob;
        }

        // PUT: api/Applyjobs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplyjob(int id, Applyjob applyjob)
        {
            if (id != applyjob.ApplyId)
            {
                return BadRequest();
            }

            _context.Entry(applyjob).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplyjobExists(id))
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

        // POST: api/Applyjobs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Applyjob>> PostApplyjob(Applyjob applyjob)
        {
            _context.Applyjob.Add(applyjob);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplyjob", new { id = applyjob.ApplyId }, applyjob);
        }

        // DELETE: api/Applyjobs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Applyjob>> DeleteApplyjob(int id)
        {
            var applyjob = await _context.Applyjob.FindAsync(id);
            if (applyjob == null)
            {
                return NotFound();
            }

            _context.Applyjob.Remove(applyjob);
            await _context.SaveChangesAsync();

            return applyjob;
        }

        private bool ApplyjobExists(int id)
        {
            return _context.Applyjob.Any(e => e.ApplyId == id);
        }
    }
}
