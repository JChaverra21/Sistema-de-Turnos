using System;
using System.ComponentModel.DataAnnotations;

namespace Turno.Models
{
    public class Cita
    {
        [Key]
        public int IdCita { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        [Display(Name = "Fecha hora ini.")]
        public DateTime FechaHoraInicio { get; set; }
        [Display(Name = "Fecha hora fin")]
        public DateTime FechaHoraFin { get; set; }
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
    }
}