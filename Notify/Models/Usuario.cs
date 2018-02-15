using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Notify.Models
{
    public class Usuario
    {
        //Comentario
        
        public String nombre { get; set; }
        public String contraseña { get; set; }
        [Key]
        public String correo { get; set; }

        public virtual List<Pedido> envio_correo { get; set; } = new List<Pedido>();
    }
}