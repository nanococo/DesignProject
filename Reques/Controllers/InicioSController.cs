using Reques.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reques.Controllers
{
    public class InicioSController : Controller
    {
        // GET: InicioS

        public ActionResult Iniciar()
        {
            var n = new PageHeader() { header = "Login" };
            return View(n);
        }

        public ActionResult SignUp() {
            var n = new PageHeader() { header = "Sign Up" };

            return View(n);
        }

        public ActionResult InsertaU(String name, String lastname, String email,String password)
        {
            var b = new Base();

            int r= b.RegistrarUsuario(name, lastname, email, password);
            if (r == 1)
            {
                return Content("1");
            }

            else
            {
                return Content("Ya existe este correo registrado ");
            }
            
        }

        public ActionResult IniciaSesion(String username, String password)
        {
            var b = new Base();

            int r = b.BuscarUsuario(username, password);
            if (r == 1)
            {
                return Content("1");
            }

            else
            {
                return Content("No coinciden los datos, verifique que el correo y contraseña estén corretamente ");
            }

        }

        public ActionResult ProjectRequirements() {
            var n = new PageHeader() { header = "Project Requirements" };
            return View(n);
        }

        public ActionResult RolesAndCollaborators() {
            var n = new PageHeader() { header = "Roles and Collaborators" };
            return View(n);
        }

        public ActionResult RequirementView() {

            var n = new PageHeader() { header = "Requirement" };
            return View(n);
        }


    }
} 