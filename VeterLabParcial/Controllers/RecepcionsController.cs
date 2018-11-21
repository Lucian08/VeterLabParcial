using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VeterLabParcial.Models;

namespace VeterLabParcial.Controllers
{
    public class RecepcionsController : Controller
    {
        private VeterLabParcialEntities db = new VeterLabParcialEntities();

        // GET: Recepcions
        public ActionResult Index()
        {
            var recepcion = db.Recepcion.Include(r => r.Cliente).Include(r => r.Laboratorio);
            return View(recepcion.ToList());
        }

        // GET: Recepcions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recepcion recepcion = db.Recepcion.Find(id);
            if (recepcion == null)
            {
                return HttpNotFound();
            }
            return View(recepcion);
        }

        // GET: Recepcions/Create
        public ActionResult Create()
        {
            ViewBag.IdCli = new SelectList(db.Cliente, "Id", "Nombre");
            ViewBag.IdLab = new SelectList(db.Laboratorio, "Id", "Nombre");
            return View();
        }

        // POST: Recepcions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdCli,IdLab,Folio,FechaRecepcion,FechaEntrega,Localidad,CantidadMuestra")] Recepcion recepcion)
        {
            if (ModelState.IsValid)
            {
                db.Recepcion.Add(recepcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCli = new SelectList(db.Cliente, "Id", "Nombre", recepcion.IdCli);
            ViewBag.IdLab = new SelectList(db.Laboratorio, "Id", "Nombre", recepcion.IdLab);
            return View(recepcion);
        }

        // GET: Recepcions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recepcion recepcion = db.Recepcion.Find(id);
            if (recepcion == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCli = new SelectList(db.Cliente, "Id", "Nombre", recepcion.IdCli);
            ViewBag.IdLab = new SelectList(db.Laboratorio, "Id", "Nombre", recepcion.IdLab);
            return View(recepcion);
        }

        // POST: Recepcions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdCli,IdLab,Folio,FechaRecepcion,FechaEntrega,Localidad,CantidadMuestra")] Recepcion recepcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recepcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCli = new SelectList(db.Cliente, "Id", "Nombre", recepcion.IdCli);
            ViewBag.IdLab = new SelectList(db.Laboratorio, "Id", "Nombre", recepcion.IdLab);
            return View(recepcion);
        }

        // GET: Recepcions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recepcion recepcion = db.Recepcion.Find(id);
            if (recepcion == null)
            {
                return HttpNotFound();
            }
            return View(recepcion);
        }

        // POST: Recepcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recepcion recepcion = db.Recepcion.Find(id);
            db.Recepcion.Remove(recepcion);
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
