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
    public class JOBController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/JOB
        public IQueryable<JOB> GetJOB()
        {
            return db.JOB;
        }

        // GET: api/JOB/5
        [ResponseType(typeof(JOB))]
        public async Task<IHttpActionResult> GetJOB(int id)
        {
            JOB jOB = await db.JOB.FindAsync(id);
            if (jOB == null)
            {
                return NotFound();
            }

            return Ok(jOB);
        }

        // PUT: api/JOB/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutJOB(int id, JOB jOB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jOB.jobId)
            {
                return BadRequest();
            }

            db.Entry(jOB).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JOBExists(id))
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

        // POST: api/JOB
        [ResponseType(typeof(JOB))]
        public async Task<IHttpActionResult> PostJOB(JOB jOB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.JOB.Add(jOB);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = jOB.jobId }, jOB);
        }

        // DELETE: api/JOB/5
        [ResponseType(typeof(JOB))]
        public async Task<IHttpActionResult> DeleteJOB(int id)
        {
            JOB jOB = await db.JOB.FindAsync(id);
            if (jOB == null)
            {
                return NotFound();
            }

            db.JOB.Remove(jOB);
            await db.SaveChangesAsync();

            return Ok(jOB);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JOBExists(int id)
        {
            return db.JOB.Count(e => e.jobId == id) > 0;
        }
    }
}