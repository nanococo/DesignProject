﻿using Reques.Models;
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
        private String CorreoN = "sebas_alpizar@hotmail.com";

        public ActionResult Iniciar()
        {

            return View();
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

        public ActionResult ActivityView() {
            return View();
        }

        public ActionResult Projects() {

            var n = new Mprojects(CorreoN);

            return View(n);
        }

        public ActionResult InsertaU(String name, String lastname, String email, String password)
        {
            var b = new Base();

            int r = b.RegistrarUsuario(name, lastname, email, password);
            if (r == 1)
            {
                return Content("1");
            }

            else
            {
                return Content("Ya existe este correo registrado ");
            }

        }

        public ActionResult InsertaR(String name, String description, String radio, String projectId) {
            var b = new Base();

            b.RegistrarRequerimiento(name, description, radio, projectId);
            return Content("1");
        }

        public ActionResult InsertaP(String name, String description) {
            var b = new Base();
            b.RegistrarProyecto(name, description);
            int x = b.getLatProjectId();
            b.Inserta_Proyectos_X_Usuarios(CorreoN, x);
            return Content("1");
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

        public ActionResult CreateProject() {
            return View();
        }

        public ActionResult CreateRequirement() {
            return View();
        }
    }
} 