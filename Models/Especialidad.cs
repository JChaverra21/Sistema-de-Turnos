using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Turno.Models
{
    public class Especialidad
    {
        //Especificar que este campo es primary key
        [Key]
        public int IdEspecialidad { get; set; } //Primary key de la tabla
        [StringLength(200, ErrorMessage = "El campo descripción debe tener como máximo 200 caracteres")]
        [Required (ErrorMessage = "Debe ingresar una descripción")]
        [Display (Name = "Descripción", Prompt = "Ingrese una descripción")]
        public string Descripcion { get; set;} //segundo atributo
        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }
    }
}