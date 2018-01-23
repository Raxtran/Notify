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
        public String nombre;
        public int precio;

    }
}