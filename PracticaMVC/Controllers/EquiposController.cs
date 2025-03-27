using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PracticaMVC.Models;
using PracticaMVC.Services;

namespace PracticaMVC.Controllers
{
    public class EquiposController : Controller
    {

        private readonly equiposDbContext _equiposDbcontext;
        public EquiposController(equiposDbContext equiposDbContext)
        {
            _equiposDbcontext = equiposDbContext;
        }
        [Autenticacion]
        public IActionResult Index()
        {
            var listaDeMarcas = (from m in _equiposDbcontext.marcas
                                 select m).ToList();
            ViewData["listadoDeMarcas"] = new SelectList(listaDeMarcas, "id_marcas", "nombre_marca");
            
            var listadoDeEquipos = (from e in _equiposDbcontext.equipos
                                    join m in _equiposDbcontext.marcas on e.marca_id equals m.id_marcas 
                                    select new {
                                        nombre = e.nombre,
                                        descripcion = e.descripcion,
                                        marca_id = e.marca_id,
                                        marca_nombre = m.nombre_marca
                                    }).ToList();
            ViewData["listadoDeEquipos"] = listadoDeEquipos;

            return View();
        }
        public IActionResult CrearEquipos(equipos nuevoEquipo)
        {
            _equiposDbcontext.Add(nuevoEquipo);
            _equiposDbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
