using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Notify.Models
{
    public class Pedido
    {
        [Key]
        public int id_pedido { get; set; }

        //importe total del pedido
        [DefaultValue(0)]
        public double total { get; set; }

        //fecha
        public DateTime fecha { get; set; } = DateTime.Now;

       

        //fk a usuari que hace el pedido
        public virtual ApplicationUser usuario { get; set; }

        //propiedad de navegacion a líneas
        public virtual List<Linea> lineas_de_pedido { get; set; } = new List<Linea>();
    }
}