using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReportesWeb.Models
{
    public class Tipo_falla_reporte
    {
        [Key]
        public Guid Id_tipo_reporteID { get; set; }
        public Guid Id_tipo_fallaID { get; set; }
        public Guid Id_reporteID { get; set; }

        #region Enlaces a otras tablas
        public virtual Tipo_falla Id_tipo_falla { get; set; } //pide que le asignes id de tipo de falla
        public virtual Reportes Id_reporte { get; set; } //pide que le asignes id de reportes
        #endregion
    }
}