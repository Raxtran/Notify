using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Notify.Models
{
    public class Pedido
    {
        [Key]
        public int id_pedido { get; set; }
        public int codigo_linea { get; set; }
        double total { get; set; }
        [StringLength(50)]
        public String Usuario_pk { get; set; }
        public virtual Usuario user { get; set; }


        public virtual List<Linea> envio_id_pedido { get; set; } = new List<Linea>();
    }
}