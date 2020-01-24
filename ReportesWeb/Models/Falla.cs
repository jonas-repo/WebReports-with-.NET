using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReportesWeb.Models
{
    public class Falla
    {
        [Key]
        public Guid Id_fallaID { get; set;}
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Url_imagen { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_inicio_falla { get; set;}
        public string Numero_Seguimiento { get; set; }
        public string Estado { get; set; }
        public Guid Id_usuario { get; set; }
        public Guid Id_tipo_fallaID { get; set; }

        #region Enlaces a otras tablas
        public virtual Tipo_falla Id_tipo_falla { get; set; } //pide que le asignes id de tipo de falla
        public virtual ICollection<Reportes> Reportes { get; set; }
        #endregion       
    }
}