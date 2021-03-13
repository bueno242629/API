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
    public class CAREERSController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/CAREERS
        public IEnumerable<CAREERS> GetCAREERS()
        {
            return db.CAREERS.ToList();
        }

        // GET: api/CAREERS/5
        [ResponseType(typeof(CAREERS))]
        public async Task<IHttpActionResult> GetCAREERS(int id)
        {
            CAREERS cAREERS = await db.CAREERS.FindAsync(id);
            if (cAREERS == null)
            {
                return NotFound();
            }

            return Ok(cAREERS);
        }

        // PUT: api/CAREERS/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCAREERS(int id, CAREERS cAREERS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cAREERS.careerId)
            {
                return BadRequest();
            }

            db.Entry(cAREERS).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CAREERSExists(id))
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

        // POST: api/CAREERS
        [ResponseType(typeof(CAREERS))]
        public async Task<IHttpActionResult> PostCAREERS(CAREERS cAREERS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CAREERS.Add(cAREERS);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cAREERS.careerId }, cAREERS);
        }

        // DELETE: api/CAREERS/5
        [ResponseType(typeof(CAREERS))]
        public async Task<IHttpActionResult> DeleteCAREERS(int id)
        {
            CAREERS cAREERS = await db.CAREERS.FindAsync(id);
            if (cAREERS == null)
            {
                return NotFound();
            }

            db.CAREERS.Remove(cAREERS);
            await db.SaveChangesAsync();

            return Ok(cAREERS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CAREERSExists(int id)
        {
            return db.CAREERS.Count(e => e.careerId == id) > 0;
        }
    }
}