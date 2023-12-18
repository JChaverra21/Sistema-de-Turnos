using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turno.Models;

namespace Turno.Controllers
{
    public class EspecialidadController : Controller
    {
        //Variable privada de solo lectura
        private readonly TurnoContext _context;
        //Constructor
        public EspecialidadController(TurnoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Especialidad.ToListAsync());
        }

        public async Task<IActionResult> Edit(int? id)
        {
            //validacion
            if (id == null)
            {
                return NotFound(); //Retornamos error 404
            }

            var especialidad = await _context.Especialidad.FindAsync(id);

            if (especialidad == null)
            {
                return NotFound(); //si no existe el id retorna error 404
            }

            return View(especialidad);
        }

        [HttpPost] //Esto diferencia el metodo Edit que graba, del edit de vista.
        public async Task<IActionResult> Edit(int id, [Bind("IdEspecialidad,Descripcion")] Especialidad especialidad)
        {
            if (id != especialidad.IdEspecialidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(especialidad);
        }

        //Metodo Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var especialidad = await _context.Especialidad.FirstOrDefaultAsync(e => e.IdEspecialidad == id);
            //Validar objeto especialidad
            if (especialidad == null)
            {
                return NotFound();
            }
            return View(especialidad);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var especialidad = await _context.Especialidad.FindAsync(id);
            _context.Especialidad.Remove(especialidad);
            await _context.SaveChangesAsync(); //Guarda definitavamente la eliminacion

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdEspecialidad, Descripcion")] Especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}