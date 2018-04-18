using LaMiaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LaMiaApp.Controllers.Api
{
    public class TrattamentoController : ApiController
    {
        private ApplicationDbContext _context;

        public TrattamentoController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: api/Trattamento
        public IHttpActionResult GetTrattamento(string query = null)
        {
            if (!String.IsNullOrWhiteSpace(query))
            {
                return Ok(_context.Trattamenti
                      .Where(c => c.Nome.ToUpper().Contains(query.ToUpper()))
                      .Select(c => new { c.Id, c.Nome, c.DurataInMinuti })
                      .ToList());
            }
            
            //else
            var trattamenti = _context.Trattamenti
                .Select(c => new { c.Id, c.Nome, c.DurataInMinuti })
                .ToList();

            return Ok(trattamenti);
        }

        public IHttpActionResult GetTrattamentiByAppuntamento(int appuntamentoId)
        {

            var result = (from t in _context.Trattamenti
                         from a in _context.Appuntamenti
                         where a.Id == appuntamentoId
                         select new
                         {
                             t.Id,
                             t.Nome
                         }).ToList();

            return Ok(result);
        }
    }
}
