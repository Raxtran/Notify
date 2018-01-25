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
        public int codigo;
        [StringLength(50)]
        public String nombre;
        public int precio;


        public virtual List<Linea> envio_nombre_producto { get; set; } = new List<Linea>();
    }
}