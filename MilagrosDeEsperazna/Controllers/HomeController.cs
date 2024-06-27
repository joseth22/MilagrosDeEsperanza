using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using MilagrosDeEsperanza.Models;

namespace MilagrosDeEsperazna.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbmilagrosEsperanzaContext _context;

        public HomeController(DbmilagrosEsperanzaContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Formulario()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EnviarFormulario(Voluntario voluntario, int interes)
        {
            if (ModelState.IsValid)
            {
                // Asignar el interés al voluntario
                voluntario.VoluntariosProyectos.Add(new VoluntariosProyecto { IdProyecto = interes });

                _context.Voluntarios.Add(voluntario);
                await _context.SaveChangesAsync();

                return RedirectToAction("MensajeEnviado");
            }

            return View("Formulario", voluntario);
        }


        public ActionResult Contact()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                comentario.FechaEnvio = DateTime.Now;

                _context.Comentarios.Add(comentario);
                await _context.SaveChangesAsync();

                
                return RedirectToAction("MensajeEnviado");
            }

            
            return View(comentario);
        }

        public ActionResult MensajeEnviado()
        {
            
            return View();
        }


        public ActionResult Proyectos()
        {

            return View();
        }

        public ActionResult Noticias()
        {

            return View();
        }
        public ActionResult About()
        {

            return View();
        }

        public ActionResult Donaciones()
        {

            return View();
        }

        public ActionResult Admin()
        {

            return View();
        }

       
    }

}
