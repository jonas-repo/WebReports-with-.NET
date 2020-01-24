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
    public class Tipo_fallaController : Controller
    {
        private ReportesContext db = new ReportesContext();

        // GET: Tipo_falla
        public ActionResult Index()
        {
            return View(db.Tipo_falla.ToList());
        }

        // GET: Tipo_falla/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_falla tipo_falla = db.Tipo_falla.Find(id);
            if (tipo_falla == null)
            {
                return HttpNotFound();
            }
            return View(tipo_falla);
        }

        // GET: Tipo_falla/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_falla/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_tipo_fallaID,Nombre_falla,Descripcion_falla")] Tipo_falla tipo_falla)
        {
            if (ModelState.IsValid)
            {
                tipo_falla.Id_tipo_fallaID = Guid.NewGuid();
                db.Tipo_falla.Add(tipo_falla);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_falla);
        }

        // GET: Tipo_falla/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_falla tipo_falla = db.Tipo_falla.Find(id);
            if (tipo_falla == null)
            {
                return HttpNotFound();
            }
            return View(tipo_falla);
        }

        // POST: Tipo_falla/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_tipo_fallaID,Nombre_falla,Descripcion_falla")] Tipo_falla tipo_falla)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_falla).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_falla);
        }

        // GET: Tipo_falla/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_falla tipo_falla = db.Tipo_falla.Find(id);
            if (tipo_falla == null)
            {
                return HttpNotFound();
            }
            return View(tipo_falla);
        }

        // POST: Tipo_falla/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Tipo_falla tipo_falla = db.Tipo_falla.Find(id);
            db.Tipo_falla.Remove(tipo_falla);
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
