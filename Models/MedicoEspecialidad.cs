namespace Turno.Models
{
    public class MedicoEspecialidad
    {
        /* Se define las relaciones que van a tener los campos, el modelo va a tener una relacion directa
        con las dos entidades Medico y Especialidad */
        public int IdMedico { get; set; }
        public int IdEspecialidad { get; set; }
        public Medico Medico { get; set; }
        public Especialidad Especialidad { get; set; }
    }
}