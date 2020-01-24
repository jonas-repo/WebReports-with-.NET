using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReportesWeb.Models
{
    public class Reportes
    {
        [Key]
        public Guid Id_reporteID { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public DateTime Fecha_fin { get; set; }
        public string Resumen { get; set; }
        public Guid Id_fallaID { get; set; }

        #region Enlaces a otras tablas
        public virtual Falla Id_falla { get; set; } //pide que le asignes id de falla
        public virtual ICollection<Tipo_falla_reporte> Tipo_falla_reportes { get; set; }//desde aqui podemos acceder a la lista de Tipo_falla_reportes
        #endregion
    }
}