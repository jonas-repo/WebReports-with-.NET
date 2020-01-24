using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReportesWeb.Models
{
    public class Tipo_falla
    {
        [Key]
        public Guid Id_tipo_fallaID { get; set;}
        public string Nombre_falla { get; set; }
        public string Descripcion_falla { get; set;}


        #region Enlaces a otras tablas
        public virtual ICollection<Falla> Fallas { get; set;}//desde aqui podemos acceder a la lista de fallas
        #endregion


    }
}