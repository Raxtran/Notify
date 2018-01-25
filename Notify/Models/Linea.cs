using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Notify.Models
{
    public class Linea
    {
        [Key]
        public int id_linea { get; set; }
        public int cantidad { get; set; }

        [StringLength(50)]
        public String recibo_nombre { get; set; }
        public virtual Producto producto { get; set; }

        public int recibo_codi { get; set; }
        public virtual Pedido codigo { get; set; }
    }
}