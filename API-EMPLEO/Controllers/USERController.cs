﻿using System;
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
    public class USERController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/USER
        public IEnumerable<USERS> GetUSERS()
        {
            return db.USERS.ToList();
        }

        // GET: api/USER/5
        [ResponseType(typeof(USERS))]
        public async Task<IHttpActionResult> GetUSERS(int id)
        {
            USERS uSERS = await db.USERS.FindAsync(id);
            if (uSERS == null)
            {
                return NotFound();
            }

            return Ok(uSERS);
        }

        [HttpGet]
        [ResponseType(typeof(USERS))]
        public async Task<IHttpActionResult> Login(string user, string pass)
        {
            USERS uSERS = await db.USERS.Where(x => x.userName == user && x.userPass == pass).FirstOrDefaultAsync();
            if (uSERS == null)
            {
                return NotFound();
            }

            return Ok(uSERS);
        }

        // PUT: api/USER/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUSERS(int id, USERS uSERS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uSERS.userId)
            {
                return BadRequest();
            }

            db.Entry(uSERS).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!USERSExists(id))
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

        // POST: api/USER
        [ResponseType(typeof(USERS))]
        public async Task<IHttpActionResult> PostUSERS(USERS uSERS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.USERS.Add(uSERS);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = uSERS.userId }, uSERS);
        }

        // DELETE: api/USER/5
        [ResponseType(typeof(USERS))]
        public async Task<IHttpActionResult> DeleteUSERS(int id)
        {
            USERS uSERS = await db.USERS.FindAsync(id);
            if (uSERS == null)
            {
                return NotFound();
            }

            db.USERS.Remove(uSERS);
            await db.SaveChangesAsync();

            return Ok(uSERS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool USERSExists(int id)
        {
            return db.USERS.Count(e => e.userId == id) > 0;
        }
    }
}