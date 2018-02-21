using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Nom")]
        public String nombre { get; set; }
        [DisplayName("Preu")]
        public decimal precio { get; set; }
        [DisplayName("Quantitat")]
        [DefaultValue(0)]
        public int qtt { get; set; }

        public virtual List<Linea> envio_nombre_producto { get; set; } = new List<Linea>();
    }
}