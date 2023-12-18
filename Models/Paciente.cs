using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Turno.Models
{
    public class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }
        [Required (ErrorMessage = "Debe ingresar un nombre")]
        public string Nombre { get; set; }
        [Required (ErrorMessage = "Debe ingresar un apellido")]
        public string Apellido { get; set; }
        [Required (ErrorMessage = "Debe ingresar un dirección")]
        [Display (Name = "Dirección")]
        public string Direccion { get; set; }
        [Required (ErrorMessage = "Debe ingresar un teléfono")]
        [Display (Name = "Teléfono")]
        public string Telefono { get; set; }
        [Required (ErrorMessage = "Debe ingresar un email")]
        [EmailAddress (ErrorMessage = "No es una dirección de email válida")]
        public string Email { get; set; }
        public List<Cita> Cita { get; set; }
    }
}