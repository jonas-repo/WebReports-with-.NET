using ReportesWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ReportesWeb.Context
{   //esta clase realiza la conexión a la base de datos si quieres ver mas de la configuraacion ve a webcon
    public class ReportesContext : DbContext
    {

        public virtual DbSet<Falla> Falla { get; set; }
        public virtual DbSet<Tipo_falla> Tipo_falla { get; set; }
        public virtual DbSet<Tipo_falla_reporte> Tipo_falla_reporte { get; set; }
        public virtual DbSet<Reportes> Reportes { get; set; }
        
    }
}