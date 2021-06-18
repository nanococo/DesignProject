using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Reques.Models
{
    public class Mprojects
    {
        readonly string connectionString = "Server=192.168.39.199;Database=Reques;User Id=waifuBot;Password=pass1234;";
 
        public List<ArrayList> proyectos = new List<ArrayList>();
        public List<ArrayList> actividades = new List<ArrayList>();


        public Mprojects(String correo)
        {
            var db = new Base();
            proyectos = db.getAllProjects();
            actividades = db.getAllActivities();
        }
    }
}