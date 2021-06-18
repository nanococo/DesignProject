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
            proyectos = new Base().getAllProjects();
            //buscarActividadPorUsuario(correo);
        }

        public void buscarActividadPorUsuario(String correo) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                conn.Open();
                SqlCommand comando = new SqlCommand("Exec Actividades_Usuario '" + correo + "'", conn);

                SqlDataReader m = comando.ExecuteReader();

                String nombre = "";
                int id = 0;
                int contador = 4;
                while (m.Read() && contador > 0) {
                    nombre = (String)m["Name"];
                    id = (int)m["ID"];

                    var actividad = new ArrayList() { nombre, id };
                    actividades.Add(actividad);

                    contador--;

                }
            }
        }
    }
}