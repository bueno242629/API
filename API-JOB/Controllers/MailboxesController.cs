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
    public class MailboxesController : ControllerBase
    {
        private readonly EmploymentDBContext _context;

        public MailboxesController(EmploymentDBContext context)
        {
            _context = context;
        }

        // GET: api/Mailboxes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mailbox>>> GetMailbox()
        {
            return await _context.Mailbox.ToListAsync();
        }

        // GET: api/Mailboxes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mailbox>> GetMailbox(int id)
        {
            var mailbox = await _context.Mailbox.FindAsync(id);

            if (mailbox == null)
            {
                return NotFound();
            }

            return mailbox;
        }

        // PUT: api/Mailboxes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMailbox(int id, Mailbox mailbox)
        {
            if (id != mailbox.MailId)
            {
                return BadRequest();
            }

            _context.Entry(mailbox).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MailboxExists(id))
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

        // POST: api/Mailboxes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Mailbox>> PostMailbox(Mailbox mailbox)
        {
            _context.Mailbox.Add(mailbox);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMailbox", new { id = mailbox.MailId }, mailbox);
        }

        // DELETE: api/Mailboxes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mailbox>> DeleteMailbox(int id)
        {
            var mailbox = await _context.Mailbox.FindAsync(id);
            if (mailbox == null)
            {
                return NotFound();
            }

            _context.Mailbox.Remove(mailbox);
            await _context.SaveChangesAsync();

            return mailbox;
        }

        private bool MailboxExists(int id)
        {
            return _context.Mailbox.Any(e => e.MailId == id);
        }
    }
}
