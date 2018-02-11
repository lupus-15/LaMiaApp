using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LaMiaApp.Models;

namespace LaMiaApp.Controllers
{
    public class TrattamentoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Trattamento
        public ActionResult Index()
        {
            return View(db.Trattamenti.ToList());
        }

        // GET: Trattamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trattamento trattamento = db.Trattamenti.Find(id);
            if (trattamento == null)
            {
                return HttpNotFound();
            }
            return View(trattamento);
        }

        // GET: Trattamento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trattamento/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,DurataInMinuti,Prezzo,Descrizione")] Trattamento trattamento)
        {
            if (ModelState.IsValid)
            {
                db.Trattamenti.Add(trattamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trattamento);
        }

        // GET: Trattamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trattamento trattamento = db.Trattamenti.Find(id);
            if (trattamento == null)
            {
                return HttpNotFound();
            }
            return View(trattamento);
        }

        // POST: Trattamento/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,DurataInMinuti,Prezzo,Descrizione")] Trattamento trattamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trattamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trattamento);
        }

        // GET: Trattamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trattamento trattamento = db.Trattamenti.Find(id);
            if (trattamento == null)
            {
                return HttpNotFound();
            }
            return View(trattamento);
        }

        // POST: Trattamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trattamento trattamento = db.Trattamenti.Find(id);
            db.Trattamenti.Remove(trattamento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
