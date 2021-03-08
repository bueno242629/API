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
    public class APPLYJOBController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/APPLYJOB
        public IQueryable<APPLYJOB> GetAPPLYJOB()
        {
            return db.APPLYJOB;
        }

        // GET: api/APPLYJOB/5
        [ResponseType(typeof(APPLYJOB))]
        public async Task<IHttpActionResult> GetAPPLYJOB(int id)
        {
            APPLYJOB aPPLYJOB = await db.APPLYJOB.FindAsync(id);
            if (aPPLYJOB == null)
            {
                return NotFound();
            }

            return Ok(aPPLYJOB);
        }

        // PUT: api/APPLYJOB/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAPPLYJOB(int id, APPLYJOB aPPLYJOB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aPPLYJOB.applyId)
            {
                return BadRequest();
            }

            db.Entry(aPPLYJOB).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!APPLYJOBExists(id))
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

        // POST: api/APPLYJOB
        [ResponseType(typeof(APPLYJOB))]
        public async Task<IHttpActionResult> PostAPPLYJOB(APPLYJOB aPPLYJOB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.APPLYJOB.Add(aPPLYJOB);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = aPPLYJOB.applyId }, aPPLYJOB);
        }

        // DELETE: api/APPLYJOB/5
        [ResponseType(typeof(APPLYJOB))]
        public async Task<IHttpActionResult> DeleteAPPLYJOB(int id)
        {
            APPLYJOB aPPLYJOB = await db.APPLYJOB.FindAsync(id);
            if (aPPLYJOB == null)
            {
                return NotFound();
            }

            db.APPLYJOB.Remove(aPPLYJOB);
            await db.SaveChangesAsync();

            return Ok(aPPLYJOB);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool APPLYJOBExists(int id)
        {
            return db.APPLYJOB.Count(e => e.applyId == id) > 0;
        }
    }
}