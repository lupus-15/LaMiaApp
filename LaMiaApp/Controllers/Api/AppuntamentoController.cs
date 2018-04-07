using LaMiaApp.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;


namespace LaMiaApp.Controllers.Api
{
    public class AppuntamentoController : ApiController
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: api/Appuntamento
        public IHttpActionResult GetAppuntamenti(string start = "2000-01-01T00:00:00", string end = "2100-01-01T00:00:00")
        {
            //12/10/2017 14:00:00
            DateTime da = DateTime.ParseExact(start, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            DateTime a = DateTime.ParseExact(end, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);

            var result = from app in _context.Appuntamenti
                            where app.DataInizio >= da && app.DataFine <= a
                            select new
                            {
                                title = app.Cliente.Nome + " " + app.Cliente.Cognome,
                                start = app.DataInizio,
                                end = app.DataFine
                            };


            return Ok(result);
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
        [Route("api/Appuntamento/PostAppuntamento")]
        [HttpPost]
        public IHttpActionResult PostAppuntamento(int? AppuntamentoId, int? ClienteId,/* List<int> Trattamenti, */DateTime DataInizio, DateTime DataFine)
        {
            //TODO: Controllo se arrivano valori non validi

            var appuntamento = new Appuntamento();

            if (AppuntamentoId != null)
            {
                appuntamento.Id = _context.Appuntamenti.Find(AppuntamentoId).Id;
            }

            appuntamento.Cliente = _context.Clienti.Find(ClienteId);
            // appuntamento.Trattamenti = _context.Trattamenti.Where(x => Trattamenti.Contains(x.Id)).ToList();
            appuntamento.DataInizio = DataInizio;
            appuntamento.DataFine = DataFine;

            _context.Appuntamenti.Add(appuntamento);
            _context.SaveChanges();

            return Ok();
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