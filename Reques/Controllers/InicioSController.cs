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
            var n = new Inicio() { Nombre = "Jocxan", Contra = "123" };
            return View(n);
        }
    }
}