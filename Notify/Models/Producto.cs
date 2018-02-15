using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Notify.Models
{
    public class Producto
    {
        [Key]
        public int codigo { get; set; } 
        [StringLength(50)]
        public String nombre { get; set; }
        public int precio { get; set; }


        public virtual List<Linea> envio_nombre_producto { get; set; } = new List<Linea>();
    }
}