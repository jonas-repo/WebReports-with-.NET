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
    public class MostrarFallasController : Controller
    {
        private ReportesContext db = new ReportesContext();

        // GET: MostrarFallas
        #region busqueda de fallas
        public ActionResult Search()
        {
            ViewBag.Id_tipo_fallaID = new SelectList(db.Tipo_falla, "Id_tipo_fallaID", "Nombre_falla");
            var fallaToShow = db.Falla.Include(f => f.Id_tipo_falla);
            return View(fallaToShow.ToList());
        }

        // POST: Prueba/Create
        [HttpPost]
        public ActionResult Search([Bind(Include = "Id_tipo_fallaID")] Falla falla, string fechaInicio, string fechaFin, string Nor_lat, string Nor_long, string Sur_lat, string Sur_long)
        {


            DateTime fechaIni = DateTime.Parse(fechaInicio);
            DateTime fechaEnd = DateTime.Parse(fechaFin);



            ViewBag.Id_tipo_fallaID = new SelectList(db.Tipo_falla, "Id_tipo_fallaID", "Nombre_falla");

            if (Nor_lat.Equals(""))
            {
                #region filtrado por nombre de falla y fecha
                var fallaToShow = db.Falla.Where(
                x => x.Id_tipo_fallaID.Equals(falla.Id_tipo_fallaID) &&
                x.Fecha_inicio_falla >= fechaIni &&
                x.Fecha_inicio_falla <= fechaEnd
                ).Include(f => f.Id_tipo_falla);
                #endregion
                return View(fallaToShow.ToList());
            }
            else
            {
                double surlat = Convert.ToDouble(Sur_lat);
                double norlat = Convert.ToDouble(Nor_lat);
                double surlong = Convert.ToDouble(Sur_long);
                double norlong = Convert.ToDouble(Nor_long);

                #region filtrado por nombre de falla,fecha y rango de areas

                var fallaToShow = db.Falla.Where(
                x => x.Id_tipo_fallaID.Equals(falla.Id_tipo_fallaID) &&
                x.Fecha_inicio_falla >= fechaIni &&
                x.Fecha_inicio_falla <= fechaEnd &&
                x.Latitud >= surlat &&
                x.Latitud <= norlat &&
                x.Longitud >= surlong &&
                x.Longitud <= norlong
                ).Include(f => f.Id_tipo_falla);

                #endregion
                return View(fallaToShow.ToList());
            }
        }
        #endregion

        #region mostrar domicilio de una falla en una nueva vista
        public ActionResult Domicilio(Guid id_falla)
        {
            Falla falla = new Falla();
            falla = db.Falla.Find(id_falla);
            ViewBag.lat = falla.Latitud;
            ViewBag.lon = falla.Longitud;
            ViewBag.idfalla = falla.Numero_Seguimiento;
            return View();
        }
        #endregion



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
