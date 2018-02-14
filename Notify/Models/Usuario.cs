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
        
        public String nombre;
        public String contraseña;
        [Key]
        public String correo;

        public virtual List<Pedido> envio_correo { get; set; } = new List<Pedido>();
    }
}