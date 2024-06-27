using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilagrosDeEsperanza.Models;

namespace MilagrosDeEsperanza.Controllers
{
    public class AdminController : Controller
    {
        private readonly DbmilagrosEsperanzaContext _context;

        public AdminController(DbmilagrosEsperanzaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError(string.Empty, "Por favor ingresa tu correo electrónico y contraseña.");
                return View(); 
            }

            var user = _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Dashboard", "Admin") });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Email o contraseña incorrectos.");
                return View(); 
            }
        }

        public ActionResult Logout()
        {
           
            

            return RedirectToAction("Login", "Admin");
        }

        public ActionResult Dashboard()
        {
            //List<Usuario> lista = _context.Usuarios.ToList();
            var comentarios = _context.Comentarios.ToList();

            return View(comentarios);
        }

        public ActionResult DashboardUsuario()
        {
            var usuarios = _context.Usuarios.ToList();
           

            return View(usuarios);
        }

        public ActionResult DashboardPaypal()
        {
            


            return View();
        }



        public ActionResult Login()
        {
            return View();
        }

        public ActionResult CrearUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction("Dashboard", "Admin"); 
            }
            
            return View(usuario);
        }

        public ActionResult EditarUsuario()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EditarUsuario(string id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }


        public ActionResult EliminarUsuario()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EliminarUsuario(string email)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario); 
            _context.SaveChanges(); 

            return RedirectToAction("Dashboard", "Admin"); 
        }



    }
}
