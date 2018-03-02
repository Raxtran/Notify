using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Notify.Models
{
    public class Linea
    {
        [Key]
        public int id_linea { get; set; }

        //Qtat
        [DisplayName("Quantitat")]
        [Range(1, 1000000)]
        public int cantidad { get; set; }

        [DisplayName("Total")]
        [DefaultValue(0)]
        public decimal preu { get; set; }

        //fk a producte
        [DisplayName("Nom")]
        public int codigo { get; set; }
        public virtual Producto producto { get; set; }

        //fk a pedido
        public int  id_pedido { get; set; }
        public virtual Pedido pedido { get; set; }

    }
}