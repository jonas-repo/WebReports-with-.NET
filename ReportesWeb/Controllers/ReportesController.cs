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
    public class ReportesController : Controller
    {
        private ReportesContext db = new ReportesContext();

        // GET: Reportes
        public ActionResult Index()
        {
            return View(db.Reportes.ToList());
        }

        // GET: Reportes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reportes reportes = db.Reportes.Find(id);
            if (reportes == null)
            {
                return HttpNotFound();
            }
            return View(reportes);
        }

        // GET: Reportes/Create
        public ActionResult Create(Guid id_falla)
        {
            
            var falla = db.Falla.Find(id_falla);
            ViewBag.falla = falla; 
            ViewBag.Nombre_falla = db.Tipo_falla.Find(falla.Id_tipo_fallaID);
            return View();
        }

        // POST: Reportes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_reporteID,Fecha_inicio,Fecha_fin,Resumen")] Reportes reportes, string fechaInicio, string fechaFin ,string estado, Guid id_falla, string text)
        {
            #region igualar datos al modelo
            reportes.Fecha_inicio = Convert.ToDateTime(fechaInicio);
            reportes.Fecha_fin = Convert.ToDateTime(fechaFin);
            reportes.Resumen = text;
            reportes.Id_fallaID = id_falla;
            #endregion


            if (ModelState.IsValid)
            {
                #region guardar los datos del modelo reportes
                reportes.Id_reporteID = Guid.NewGuid();
                db.Reportes.Add(reportes);               
                #endregion

                #region guardar datos del estado de la falla
                Falla falla = new Falla();
                falla = db.Falla.Find(id_falla);
                falla.Estado = estado;
                db.Entry(falla).State = EntityState.Modified;
                #endregion
                db.SaveChanges();


                return RedirectToAction("Search","MostrarFallas");
            }

            return View(reportes);
        }

        // GET: Reportes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reportes reportes = db.Reportes.Find(id);
            if (reportes == null)
            {
                return HttpNotFound();
            }
            return View(reportes);
        }

        // POST: Reportes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_reporteID,Fecha_inicio,Fecha_fin,Resumen")] Reportes reportes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reportes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reportes);
        }

        // GET: Reportes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reportes reportes = db.Reportes.Find(id);
            if (reportes == null)
            {
                return HttpNotFound();
            }
            return View(reportes);
        }

        // POST: Reportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Reportes reportes = db.Reportes.Find(id);
            db.Reportes.Remove(reportes);
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
