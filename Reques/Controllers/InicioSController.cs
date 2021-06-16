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
            //Base b = new Base();
            //var n = new Inicio() { Nombre = "Jocxan", Contra = "123" };
            return View();
        }

        public ActionResult SignUp() {
            return View();
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
            return View();
        }

        public ActionResult RolesAndCollaborators() {
            return View();
        }

        public ActionResult RequirementView() {
            return View();
        }

        public ActionResult ActivityView() {
            return View();
        }

        public ActionResult Projects() {
            return View();
        }

    }
} 