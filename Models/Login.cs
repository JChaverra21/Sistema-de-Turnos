using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Turno.Models
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }
        [Required(ErrorMessage = "Debe ingresar un usuario.")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Debe ingresar una contraseña.")]
        public string Password { get; set; }


    }
}