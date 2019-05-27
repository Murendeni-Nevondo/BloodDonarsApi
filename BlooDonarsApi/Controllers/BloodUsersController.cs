using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BlooDonarsApi.Models;

namespace BlooDonarsApi.Controllers
{
    public class BloodUsersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/BloodUsers
        public IQueryable<BloodUser> GetBloodUsers()
        {
            return db.BloodUsers;
        }

        // GET: api/BloodUsers/5
        [ResponseType(typeof(BloodUser))]
        public IHttpActionResult GetBloodUser(int id)
        {
            BloodUser bloodUser = db.BloodUsers.Find(id);
            if (bloodUser == null)
            {
                return NotFound();
            }

            return Ok(bloodUser);
        }

        // PUT: api/BloodUsers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBloodUser(int id, BloodUser bloodUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bloodUser.Id)
            {
                return BadRequest();
            }

            db.Entry(bloodUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BloodUserExists(id))
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

        // POST: api/BloodUsers
        [ResponseType(typeof(BloodUser))]
        public IHttpActionResult PostBloodUser(BloodUser bloodUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BloodUsers.Add(bloodUser);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bloodUser.Id }, bloodUser);
        }

        // DELETE: api/BloodUsers/5
        [ResponseType(typeof(BloodUser))]
        public IHttpActionResult DeleteBloodUser(int id)
        {
            BloodUser bloodUser = db.BloodUsers.Find(id);
            if (bloodUser == null)
            {
                return NotFound();
            }

            db.BloodUsers.Remove(bloodUser);
            db.SaveChanges();

            return Ok(bloodUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BloodUserExists(int id)
        {
            return db.BloodUsers.Count(e => e.Id == id) > 0;
        }
    }
}