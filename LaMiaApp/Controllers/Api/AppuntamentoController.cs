using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LaMiaApp.Models;

namespace LaMiaApp.Controllers.Api
{
    public class AppuntamentoController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: api/Appuntamento
        public IHttpActionResult GetAppuntamenti(string start = "2000-01-01T00:00:00", string end = "2100-01-01T00:00:00")
        {
            //12/10/2017 14:00:00
            DateTime da = DateTime.ParseExact(start, "yyyy-MM-ddTHH:mm:ss",CultureInfo.InvariantCulture);
            DateTime a = DateTime.ParseExact(end , "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);

            var Table3Qry = from app in _context.Appuntamenti
                            join t in _context.Trattamenti
                            on app.Id equals t.Id
                            where app.DataInizio >= da && app.DataFine <= a
                            select new
                            {
                                title = app.Cliente.Nome + " " + app.Cliente.Cognome + " - " +  t.Nome,
                                start = app.DataInizio,
                                end = app.DataFine
                            };


            return Ok(Table3Qry);
        }

        // GET: api/Appuntamento/5
        [ResponseType(typeof(Appuntamento))]
        public IHttpActionResult GetAppuntamento(int id)
        {
            Appuntamento appuntamento = _context.Appuntamenti.Find(id);
            if (appuntamento == null)
            {
                return NotFound();
            }

            return Ok(appuntamento);
        }

        // PUT: api/Appuntamento/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAppuntamento(int id, Appuntamento appuntamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appuntamento.Id)
            {
                return BadRequest();
            }

            _context.Entry(appuntamento).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppuntamentoExists(id))
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

        // POST: api/Appuntamento
        [ResponseType(typeof(Appuntamento))]
        public IHttpActionResult PostAppuntamento(Appuntamento appuntamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Appuntamenti.Add(appuntamento);
            _context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = appuntamento.Id }, appuntamento);
        }

        // DELETE: api/Appuntamento/5
        [ResponseType(typeof(Appuntamento))]
        public IHttpActionResult DeleteAppuntamento(int id)
        {
            Appuntamento appuntamento = _context.Appuntamenti.Find(id);
            if (appuntamento == null)
            {
                return NotFound();
            }

            _context.Appuntamenti.Remove(appuntamento);
            _context.SaveChanges();

            return Ok(appuntamento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppuntamentoExists(int id)
        {
            return _context.Appuntamenti.Count(e => e.Id == id) > 0;
        }
    }
}