using Microsoft.EntityFrameworkCore;
using Turno.Models;

namespace Turno.Models
{
    public class TurnoContext : DbContext
    {
        //Constructor
        public TurnoContext(DbContextOptions<TurnoContext> opciones)
        : base(opciones)
        {

        }

        //Agregar entidad o tabla que se va a generar en sql server
        public DbSet<Especialidad> Especialidad { get; set; }

        //Dbset para la entidad paciente
        public DbSet<Paciente> Paciente { get; set; }
        //Dbset para la entidad Medico creado mediante Scaffolding
        public DbSet<Medico> Medico { get; set; }
        public DbSet<MedicoEspecialidad> MedicoEspecialidad { get; set; }
        public DbSet<Cita> Cita { get; set; }
        public DbSet<Login> Login { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especialidad>(entidad =>
            {
                entidad.ToTable("Especialidad");

                entidad.HasKey(e => e.IdEspecialidad);

                entidad.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            }
            );

            modelBuilder.Entity<Paciente>(entidad =>
            {
                entidad.ToTable("Paciente");

                entidad.HasKey(p => p.IdPaciente);

                entidad.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(p => p.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(p => p.Direccion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                entidad.Property(p => p.Telefono)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entidad.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            }
            );

            modelBuilder.Entity<Medico>(entidad =>
            {
                entidad.ToTable("Medico");

                entidad.HasKey(m => m.IdMedico);

                entidad.Property(m => m.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(m => m.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(m => m.Direccion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                entidad.Property(m => m.Telefono)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entidad.Property(m => m.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(m => m.HorarioAtencionDesde)
                .IsRequired()
                .IsUnicode(false);

                entidad.Property(m => m.HorarioAtencionHasta)
                .IsRequired()
                .IsUnicode(false);
            }
            );

            //Se define una Primary key compuesta por los dos campos ID de la Entidad MedicoEspecialidad
            modelBuilder.Entity<MedicoEspecialidad>().HasKey(x => new { x.IdMedico, x.IdEspecialidad });

            //Se define una restriccion entre la tabla Medico y la tabla MedicoEspecialidad
            modelBuilder.Entity<MedicoEspecialidad>().HasOne(x => x.Medico)
            /* La propiedad HasOne y WithMany se establece una relacion de 1 a muchos, es decir un Medico puede
            tener muchas especialidades */
            .WithMany(p => p.MedicoEspecialidad)

            /* La Propiedad HasForeignKey se establece cual va a ser el campo que va a formar parte de la ForeingKey
            en este caso el campo IdMedico de la tabla MedicoEspecialidad */
            .HasForeignKey(p => p.IdMedico);

            //Definir la relacion entre la entidad MedicoEspecialidad y Especialidad
            modelBuilder.Entity<MedicoEspecialidad>().HasOne(x => x.Especialidad)
            .WithMany(p => p.MedicoEspecialidad)
            .HasForeignKey(p => p.IdEspecialidad);

            modelBuilder.Entity<Cita>(entidad =>
            {
                entidad.ToTable("Cita");

                entidad.HasKey(m => m.IdCita);

                entidad.Property(m => m.IdPaciente)
                .IsRequired()
                .IsUnicode(false);

                entidad.Property(m => m.IdMedico)
                .IsRequired()
                .IsUnicode(false);

                entidad.Property(m => m.FechaHoraInicio)
                .IsRequired()
                .IsUnicode(false);

                entidad.Property(m => m.FechaHoraFin)
                .IsRequired()
                .IsUnicode(false);
            }
            );

            modelBuilder.Entity<Cita>().HasOne(x => x.Paciente)
            .WithMany(p => p.Cita)
            .HasForeignKey(p => p.IdPaciente);

            modelBuilder.Entity<Cita>().HasOne(x => x.Medico)
            .WithMany(p => p.Cita)
            .HasForeignKey(p => p.IdMedico);

            modelBuilder.Entity<Login>(entidad =>
            {
                entidad.ToTable("Login");

                entidad.HasKey(l => l.LoginId);

                entidad.Property(l => l.Usuario)
                .IsRequired(); //Indica en la tabla que el campo no puede ser nulo la propiedad IdRequired

                entidad.Property(l => l.Password)
                .IsRequired();
            });
        }
    }
}