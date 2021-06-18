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

        internal Base db = new Base();


        internal class Global {
            public static String CorreoN = "";
        }


            // GET: InicioS
            //private String CorreoN = "sebas_alpizar@hotmail.com";

        public ActionResult Iniciar(int id = 0){
            var loginModel = new LoginModel(id);
            return View(loginModel);
        }

        public ActionResult SignUp() {
            return View();
        }

        

        public ActionResult ProjectRequirements(int id) {
            var requirementData = new RequirementData(id);
            return View(requirementData);
        }

        public ActionResult RolesAndCollaborators() {
            return View();
        }

        public ActionResult RequirementView(int id) {
            var concreteRequirement = new ConcreteRequirements(id);
            return View(concreteRequirement);
        }

        public ActionResult ActivityView(int id) {
            var concreteActivity = new ConcreteActivity(id);
            return View(concreteActivity);
        }

        public ActionResult Projects() {
            var n = new Mprojects(Global.CorreoN);
            return View(n);
        }

        public ActionResult InsertaU(String name, String lastname, String email, String password)
        {
            var b = new Base();

            int r = b.signUp(name, lastname, email, password);
            if (r == 1)
            {
                return Content("1");
            }

            else
            {
                return Content("Ya existe este correo registrado ");
            }

        }

        public ActionResult InsertaR(String name, String description, String radio, String projectId, String assignee) {
            var x = db.insertRequirement(name, description, Global.CorreoN, radio, projectId, assignee);
            if (x == 1) {
                return Content("1");
            } else {
                return Content("Error al insertar requerimiento");
            }
        }

        public ActionResult InsertaP(String name, String description) {
            int x = db.insertProject(name, description);
            if (x == 1) {
                return Content("1");
            } else {
                return Content("Error isnertando proyecto");
            }
        }

        public ActionResult InsertaA(String name, String description, String assignee, String requirementId) {
            var x = db.insertActivity(name, description, Global.CorreoN, assignee, requirementId);

            if (x == 1) {
                return Content("1");
            } else {
                return Content("Error isnertando actividad");
            }
        }

        public ActionResult IniciaSesion(String username, String password) {
            int r = db.signIn(username, password);
            if (r == 1)
            {
                Global.CorreoN = username;
                return Content("1");
            }

            else
            {
                return Content("No coinciden los datos, verifique que el correo y contraseña estén corretamente ");
            }

        }

        public ActionResult CreateProject() {
            return View();
        }

        public ActionResult CreateRequirement() {
            var n = new CreateRequirementModel();
            return View(n);
        }

        public ActionResult CreateActivity() {
            var n = new CreateActivityModel();
            return View(n);
        }
    }
} 