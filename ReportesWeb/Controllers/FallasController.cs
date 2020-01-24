using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReportesWeb.Context;
using ReportesWeb.Models;

namespace ReportesWeb.Controllers
{
    public class FallasController : Controller
    {
        private ReportesContext db = new ReportesContext();

        // GET: Fallas
        public ActionResult Index()
        {
            var falla = db.Falla.Include(f => f.Id_tipo_falla);
            return View(falla.ToList());
        }

        // GET: Fallas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Falla falla = db.Falla.Find(id);
            if (falla == null)
            {
                return HttpNotFound();
            }
            return View(falla);
        }

        // GET: Fallas/Create
        public ActionResult Create()
        {
            ViewBag.validacionError = false;
            ViewBag.Id_tipo_fallaID = new SelectList(db.Tipo_falla, "Id_tipo_fallaID", "Nombre_falla");
            return View();
        }

        // POST: Fallas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_tipo_fallaID")] Falla falla, HttpPostedFileBase image, string lat, string long1, string text)
        {
           
            Random rnd = new Random();

            #region validaciones de los campos ingresados
            if(lat.Equals("") || long1.Equals("") || text.Equals("") )
            {
                ViewBag.validacionError = true;
                ViewBag.Id_tipo_fallaID = new SelectList(db.Tipo_falla, "Id_tipo_fallaID", "Nombre_falla", falla.Id_tipo_fallaID);
                return View();
            }
            if(image.Equals(null))
            {
                ViewBag.validacionError = true;
                ViewBag.Id_tipo_fallaID = new SelectList(db.Tipo_falla, "Id_tipo_fallaID", "Nombre_falla", falla.Id_tipo_fallaID);
                return View();
            }
            #endregion



            if (ModelState.IsValid)
            {
                int numeroSeguimiento = rnd.Next(10000);

                #region Parte para guardar imagen en BD y carpeta
                string path = image.FileName;
                int number = rnd.Next(10000);
                string filename = Path.GetFileNameWithoutExtension(path);
                string extension = Path.GetExtension(path);
                filename = filename + DateTime.Now.ToString("yymmssff") + number + extension;
                falla.Url_imagen = "/img_reports/electricidad/" + filename;
                filename = Path.Combine(Server.MapPath("~/img_reports/electricidad/"),filename);
                image.SaveAs(filename);
                #endregion

                #region igualar los campos ingresados a lo que nos pide el modelo
                DateTime fechahoy = DateTime.Today;
                falla.Fecha_inicio_falla = fechahoy;
                falla.Latitud = Convert.ToDouble(lat);
                falla.Longitud = Convert.ToDouble(long1);
                falla.Descripcion = text;
                falla.Id_usuario = new Guid();
                falla.Estado = "No revisado";
                falla.Numero_Seguimiento = DateTime.Now.ToString("yymmssff") + numeroSeguimiento + Guid.NewGuid().ToString().Substring(0,4);
                #endregion

                #region guardar en la base de datos
                falla.Id_fallaID = Guid.NewGuid();
                db.Falla.Add(falla);
                db.SaveChanges();
                #endregion

                #region redirigir al usuario
                return RedirectToAction("Success", "Fallas", new { numero = falla.Numero_Seguimiento });
                #endregion

            }

            ViewBag.Id_tipo_fallaID = new SelectList(db.Tipo_falla, "Id_tipo_fallaID", "Nombre_falla", falla.Id_tipo_fallaID);
            return View(falla);
        }

        public ActionResult Success(string numero)
        {
            ViewBag.num = numero;
            return View();
        }




        // GET: Fallas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Falla falla = db.Falla.Find(id);
            if (falla == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_tipo_fallaID = new SelectList(db.Tipo_falla, "Id_tipo_fallaID", "Nombre_falla", falla.Id_tipo_fallaID);
            return View(falla);
        }

        // POST: Fallas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_fallaID,Latitud,Longitud,Url_imagen,Descripcion,Fecha_inicio_falla,Id_usuario,Id_tipo_fallaID")] Falla falla)
        {
            if (ModelState.IsValid)
            {
                db.Entry(falla).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_tipo_fallaID = new SelectList(db.Tipo_falla, "Id_tipo_fallaID", "Nombre_falla", falla.Id_tipo_fallaID);
            return View(falla);
        }      

        // GET: Fallas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Falla falla = db.Falla.Find(id);
            if (falla == null)
            {
                return HttpNotFound();
            }
            return View(falla);
        }

        // POST: Fallas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Falla falla = db.Falla.Find(id);
            db.Falla.Remove(falla);
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
