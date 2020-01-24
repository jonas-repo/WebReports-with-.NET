using ReportesWeb.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReportesWeb.Controllers
{
    public class PruebaController : Controller
    {
        ReportesContext context = new ReportesContext();

        // GET: Prueba/Create
        public ActionResult Search()
        {
            ViewBag.lol = "";
            return View();
        }

        // POST: Prueba/Create
        [HttpPost]
        public ActionResult Search(string hola)
        {
            string url = context.Falla.Where(z => z.Numero_Seguimiento.Equals(hola)).Select(x => x.Url_imagen).FirstOrDefault().ToString();
            ViewBag.lol = url.Replace("~","");
            return View();
        }
      
    }
}
