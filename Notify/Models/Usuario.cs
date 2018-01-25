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
        public String idcorreo { get; set; }
        public String nombre { get; set; }
        public String contraseña { get; set; } 

    }
}