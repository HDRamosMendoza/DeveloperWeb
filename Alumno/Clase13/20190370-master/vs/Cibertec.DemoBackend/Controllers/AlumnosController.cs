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
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Cibertec.DemoBackend.Models;
using System.Threading;

namespace Cibertec.DemoBackend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AlumnosController : ApiController
    {
        private ColegioDbContext db = new ColegioDbContext();

        // GET: api/Alumnos
        public IQueryable<Alumno> GetAlumnos()
        {
            //Thread.Sleep(10000);
            return db.Alumnos;
        }

        // GET: api/Alumnos/5
        [ResponseType(typeof(Alumno))]
        public async Task<IHttpActionResult> GetAlumno(int id)
        {
            Alumno alumno = await db.Alumnos.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }

            return Ok(alumno);
        }

        // PUT: api/Alumnos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAlumno(int id, Alumno alumno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alumno.Id)
            {
                return BadRequest();
            }

            db.Entry(alumno).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlumnoExists(id))
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

        // POST: api/Alumnos
        [ResponseType(typeof(Alumno))]
        public async Task<IHttpActionResult> PostAlumno(Alumno alumno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Alumnos.Add(alumno);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = alumno.Id }, alumno);
        }

        // DELETE: api/Alumnos/5
        [ResponseType(typeof(Alumno))]
        public async Task<IHttpActionResult> DeleteAlumno(int id)
        {
            Alumno alumno = await db.Alumnos.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }

            db.Alumnos.Remove(alumno);
            await db.SaveChangesAsync();

            return Ok(alumno);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlumnoExists(int id)
        {
            return db.Alumnos.Count(e => e.Id == id) > 0;
        }
    }
}