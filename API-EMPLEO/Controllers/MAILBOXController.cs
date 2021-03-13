using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using API_EMPLEO.Models;

namespace API_EMPLEO.Controllers
{
    public class MAILBOXController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/MAILBOX
        public IEnumerable<MAILBOX> GetMAILBOX()
        {
            return db.MAILBOX.ToList();
        }

        // GET: api/MAILBOX/5
        [ResponseType(typeof(MAILBOX))]
        public async Task<IHttpActionResult> GetMAILBOX(int id)
        {
            MAILBOX mAILBOX = await db.MAILBOX.FindAsync(id);
            if (mAILBOX == null)
            {
                return NotFound();
            }

            return Ok(mAILBOX);
        }

        // PUT: api/MAILBOX/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMAILBOX(int id, MAILBOX mAILBOX)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mAILBOX.mailId)
            {
                return BadRequest();
            }

            db.Entry(mAILBOX).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MAILBOXExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MAILBOX
        [ResponseType(typeof(MAILBOX))]
        public async Task<IHttpActionResult> PostMAILBOX(MAILBOX mAILBOX)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MAILBOX.Add(mAILBOX);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = mAILBOX.mailId }, mAILBOX);
        }

        // DELETE: api/MAILBOX/5
        [ResponseType(typeof(MAILBOX))]
        public async Task<IHttpActionResult> DeleteMAILBOX(int id)
        {
            MAILBOX mAILBOX = await db.MAILBOX.FindAsync(id);
            if (mAILBOX == null)
            {
                return NotFound();
            }

            db.MAILBOX.Remove(mAILBOX);
            await db.SaveChangesAsync();

            return Ok(mAILBOX);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MAILBOXExists(int id)
        {
            return db.MAILBOX.Count(e => e.mailId == id) > 0;
        }
    }
}