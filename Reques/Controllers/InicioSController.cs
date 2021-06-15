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
    }
} 