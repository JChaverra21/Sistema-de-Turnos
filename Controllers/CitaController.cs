using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Turno.Models;

namespace Turno.Controllers
{
    public class CitaController : Controller
    {
        private readonly TurnoContext _context;
        private IConfiguration _configuration;
        public CitaController(TurnoContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            ViewData["IdMedico"] = new SelectList((from medico in _context.Medico.ToList() select new { IdMedico = medico.IdMedico, NombreCompleto = medico.Nombre + " " + medico.Apellido }), "IdMedico", "NombreCompleto");
            ViewData["IdPaciente"] = new SelectList((from paciente in _context.Paciente.ToList() select new { IdPaciente = paciente.IdPaciente, NombreCompleto = paciente.Nombre + " " + paciente.Apellido }), "IdPaciente", "NombreCompleto");
            return View();
        }

        public JsonResult ObtenerCitas(int idMedico)
        {
            /* List<Cita> citas = new List<Cita>(); */
            var citas = _context.Cita.Where(t => t.IdMedico == idMedico)
            .Select(t => new {
                t.IdCita,
                t.IdMedico,
                t.IdPaciente,
                t.FechaHoraInicio,
                t.FechaHoraFin,
                paciente = t.Paciente.Nombre + ", " + t.Paciente.Apellido
            })
            .ToList();

            return Json(citas);
        }

        [HttpPost]
        public JsonResult GrabarCita(Cita cita)
        {
            var ok = false;
            try
            {
                _context.Cita.Add(cita);
                _context.SaveChanges();
                ok = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Excepción encontrada", e);
            }
            var jsonResult = new { ok = ok };
            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult EliminarCita(int idCita)
        {
            var ok = false;
            try
            {
                var citaAEliminar = _context.Cita.Where(t => t.IdCita == idCita).FirstOrDefault();
                if (citaAEliminar != null)
                {
                    _context.Cita.Remove(citaAEliminar);
                    _context.SaveChanges();
                    ok = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Excepción encontrada", e);
            }
            var jsonResult = new { ok = ok };
            return Json(jsonResult);
        }
    }
}