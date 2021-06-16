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
 
        public List<ArrayList> proyectos = new List<ArrayList>();
        public List<ArrayList> actividades = new List<ArrayList>();


        public Mprojects(String correo)
        {
            BuscarProyectos(correo);

        }

        public void BuscarProyectos(String correo)
        {
            using (SqlConnection conn = new SqlConnection("Server=LAPTOP-B9MVKMJ5;Database=Reques;User Id=Usuario;Password=1324;"))
            {
                conn.Open();
                SqlCommand comando = new SqlCommand("Exec Proyectos_Usuario '" + correo + "'", conn);

                SqlDataReader m = comando.ExecuteReader();

                String n = "";
                int id = 0;
                int contador = 4;
                while (m.Read() && contador > 0)
                {
                    n = (String)m["Nombre"];
                    id = (int)m["ID"];

                    var proyecto = new ArrayList() { n, id };
                    proyectos.Add(proyecto);

                    contador--;


                }

                contador = 3;
                comando = new SqlCommand("Exec Proyectos_Usuario '" + correo + "'", conn);

            }

        }
    }
}