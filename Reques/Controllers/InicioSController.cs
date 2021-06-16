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