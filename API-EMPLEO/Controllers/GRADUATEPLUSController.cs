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
    public class GRADUATEPLUSController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/GRADUATEPLUS
        public IEnumerable<GRADUATEPLUS> GetGRADUATEPLUS()
        {
            return db.GRADUATEPLUS.ToList();
        }

        // GET: api/GRADUATEPLUS/5
        [ResponseType(typeof(GRADUATEPLUS))]
        public async Task<IHttpActionResult> GetGRADUATEPLUS(int id)
        {
            GRADUATEPLUS gRADUATEPLUS = await db.GRADUATEPLUS.FindAsync(id);
            if (gRADUATEPLUS == null)
            {
                return NotFound();
            }

            return Ok(gRADUATEPLUS);
        }

        // PUT: api/GRADUATEPLUS/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGRADUATEPLUS(int id, GRADUATEPLUS gRADUATEPLUS)
        {
            if (!ModelState.IsValid)
                return BadRequest("This is invalid model. Please recheck!");

            var checkExistingStudent = db.GRADUATEPLUS.Where(x => x.gradId == gRADUATEPLUS.gradId).FirstOrDefault<GRADUATEPLUS>();

            if (checkExistingStudent != null)
            {
                checkExistingStudent.name = gRADUATEPLUS.name;
                checkExistingStudent.descriptionGrad = gRADUATEPLUS.descriptionGrad;
                checkExistingStudent.career = gRADUATEPLUS.career;
                checkExistingStudent.photo = gRADUATEPLUS.photo;

                await db.SaveChangesAsync();
            }
            else
                return NotFound();
            return Ok();
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (id != gRADUATEPLUS.gradId)
            //{
            //    return BadRequest();
            //}

            //db.Entry(gRADUATEPLUS).State = EntityState.Modified;

            //try
            //{
            //    await db.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!GRADUATEPLUSExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/GRADUATEPLUS
        [ResponseType(typeof(GRADUATEPLUS))]
        public async Task<IHttpActionResult> PostGRADUATEPLUS(GRADUATEPLUS gRADUATEPLUS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GRADUATEPLUS.Add(gRADUATEPLUS);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = gRADUATEPLUS.gradId }, gRADUATEPLUS);
        }

        // DELETE: api/GRADUATEPLUS/5
        [ResponseType(typeof(GRADUATEPLUS))]
        public async Task<IHttpActionResult> DeleteGRADUATEPLUS(int id)
        {
            GRADUATEPLUS gRADUATEPLUS = await db.GRADUATEPLUS.FindAsync(id);
            if (gRADUATEPLUS == null)
            {
                return NotFound();
            }

            db.GRADUATEPLUS.Remove(gRADUATEPLUS);
            await db.SaveChangesAsync();

            return Ok(gRADUATEPLUS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GRADUATEPLUSExists(int id)
        {
            return db.GRADUATEPLUS.Count(e => e.gradId == id) > 0;
        }
    }
}