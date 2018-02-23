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
        [Range(0,100)]
        public decimal precio { get; set; }

        [DisplayName("Quantitat")]
        [DefaultValue(0)]
        [Range(0, 1000000)]
        public int qtt { get; set; }

        [DisplayName("Calent?")]
        public Boolean caliente { get; set; }

        [DisplayName("Beguda?")]
        public Boolean beguda { get; set; }

        public virtual List<Linea> linias_de_pedido_donde_aparece_el_produto { get; set; } = new List<Linea>();
    }
}