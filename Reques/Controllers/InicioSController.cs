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
            var n = new PageHeader() { header = "Login" };
            return View(n);
        }

        public ActionResult SignUp() {
            var n = new PageHeader() { header = "Sign Up" };
            return View(n);
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

        public ActionResult ActivityView() {
            var n = new PageHeader() { header = "Activity" };
            return View(n);
        }

        public ActionResult Projects() {
            var n = new PageHeader() { header = "Projects" };
            return View(n);
        }

    }
} 