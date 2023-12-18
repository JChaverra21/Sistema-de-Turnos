using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Turno.Models
{
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar un apellido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Debe ingresar una dirección")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Debe ingresar un teléfono")]
        [Display(Name = "Teléfono")]

        public string Telefono { get; set; }
        [Required(ErrorMessage = "Debe ingresar un email")]
        [EmailAddress(ErrorMessage = "No es una dirección de email válida")]
        public string Email { get; set; }
        [Display(Name = "Horario desde")]
        [DataType (DataType.Time)]

        public DateTime HorarioAtencionDesde { get; set; }
        [Display(Name = "Horario hasta")]
        [DataType (DataType.Time)]
        public DateTime HorarioAtencionHasta { get; set; }

        /* Nueva propiedad a este modelo de Tipo List referenciando al modelo MedicoEspecialidad, sirve por si queremos
        mostrar en la vista Medico una lista de Especialidades disponibles para asignarle al Medico cuando lo estamos editando
        o creando (La propiedad sirve para vincular este modelo con el Modelo MedicoEspecialidad y asi poder obtener una lista de las
        especialidades que tiene asignado el medico) */
        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }
        public List<Cita> Cita { get; set; }
    }
}