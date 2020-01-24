using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReportesWeb.Context;
using ReportesWeb.Models;

namespace ReportesWeb.Controllers
{
    public class Tipo_falla_reporteController : Controller
    {
        private ReportesContext db = new ReportesContext();

        // GET: Tipo_falla_reporte
        public ActionResult Index()
        {
            var tipo_falla_reporte = db.Tipo_falla_reporte.Include(t => t.Id_reporte).Include(t => t.Id_tipo_falla);
            return View(tipo_falla_reporte.ToList());
        }

        // GET: Tipo_falla_reporte/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_falla_reporte tipo_falla_reporte = db.Tipo_falla_reporte.Find(id);
            if (tipo_falla_reporte == null)
            {
                return HttpNotFound();
            }
            return View(tipo_falla_reporte);
        }

        // GET: Tipo_falla_reporte/Create
        public ActionResult Create()
        {
            ViewBag.Id_reporteID = new SelectList(db.Reportes, "Id_reporteID", "Resumen");
            ViewBag.Id_tipo_fallaID = new SelectList(db.Tipo_falla, "Id_tipo_fallaID", "Nombre_falla");
            return View();
        }

        // POST: Tipo_falla_reporte/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_tipo_reporteID,Id_tipo_fallaID,Id_reporteID")] Tipo_falla_reporte tipo_falla_reporte)
        {
            if (ModelState.IsValid)
            {
                tipo_falla_reporte.Id_tipo_reporteID = Guid.NewGuid();
                db.Tipo_falla_reporte.Add(tipo_falla_reporte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_reporteID = new SelectList(db.Reportes, "Id_reporteID", "Resumen", tipo_falla_reporte.Id_reporteID);
            ViewBag.Id_tipo_fallaID = new SelectList(db.Tipo_falla, "Id_tipo_fallaID", "Nombre_falla", tipo_falla_reporte.Id_tipo_fallaID);
            return View(tipo_falla_reporte);
        }

        // GET: Tipo_falla_reporte/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_falla_reporte tipo_falla_reporte = db.Tipo_falla_reporte.Find(id);
            if (tipo_falla_reporte == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_reporteID = new SelectList(db.Reportes, "Id_reporteID", "Resumen", tipo_falla_reporte.Id_reporteID);
            ViewBag.Id_tipo_fallaID = new SelectList(db.Tipo_falla, "Id_tipo_fallaID", "Nombre_falla", tipo_falla_reporte.Id_tipo_fallaID);
            return View(tipo_falla_reporte);
        }

        // POST: Tipo_falla_reporte/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_tipo_reporteID,Id_tipo_fallaID,Id_reporteID")] Tipo_falla_reporte tipo_falla_reporte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_falla_reporte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_reporteID = new SelectList(db.Reportes, "Id_reporteID", "Resumen", tipo_falla_reporte.Id_reporteID);
            ViewBag.Id_tipo_fallaID = new SelectList(db.Tipo_falla, "Id_tipo_fallaID", "Nombre_falla", tipo_falla_reporte.Id_tipo_fallaID);
            return View(tipo_falla_reporte);
        }

        // GET: Tipo_falla_reporte/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_falla_reporte tipo_falla_reporte = db.Tipo_falla_reporte.Find(id);
            if (tipo_falla_reporte == null)
            {
                return HttpNotFound();
            }
            return View(tipo_falla_reporte);
        }

        // POST: Tipo_falla_reporte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Tipo_falla_reporte tipo_falla_reporte = db.Tipo_falla_reporte.Find(id);
            db.Tipo_falla_reporte.Remove(tipo_falla_reporte);
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
