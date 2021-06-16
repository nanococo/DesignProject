using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Reques.Models
{
    public class Base
    {
        SqlConnection conn;

        public Base() {
            //OpenSqlConnection();
        
        }

        public void OpenSqlConnection(String correo, int proyecto)
        {
            //"Server=LAPTOP-B9MVKMJ5,Authentication=Windows Authentication, Database=Reques"
            //using (SqlConnection conn = new SqlConnection("Server=192.168.39.199;Database=Reques;User Id=waifuBot;Password=pass1234;"))
            using (conn = new SqlConnection("Server=LAPTOP-B9MVKMJ5;Database=Reques;User Id=Usuario;Password=1324;"))
            {
                conn.Open();
                SqlCommand comando = new SqlCommand("Exec Inserta_Proyectos_X_Usuarios '" +correo + "', "+proyecto+ ", 2", conn);


                SqlDataReader m = comando.ExecuteReader();

                /*
                int r = 0;
                while (m.Read())
                {
                    r = (int)m["return_value"];
                    Console.Out.WriteLine(r);
                }*/
            }


        }



        public int RegistrarUsuario(String nombre, String apellido, String correo, String contra)
        {
            using (conn = new SqlConnection("Server=LAPTOP-B9MVKMJ5;Database=Reques;User Id=Usuario;Password=1324;"))
            {
                conn.Open();
                SqlCommand comando = new SqlCommand("Exec Inserta_Usuarios '" + nombre + "', '" + apellido + "', '" + correo + "', '" + contra + "'", conn);

                SqlDataReader m = comando.ExecuteReader();

                int r = 0;
                while (m.Read())
                {
                    r = (int)m["return_value"];
                   
                }

                return r;
            }

        }

        public int BuscarUsuario(String correo, String contra)
        {
            using (conn = new SqlConnection("Server=LAPTOP-B9MVKMJ5;Database=Reques;User Id=Usuario;Password=1324;"))
            {
                conn.Open();
                SqlCommand comando = new SqlCommand("Exec Busca_Usuarios '" + correo + "', '" + contra + "'", conn);

                SqlDataReader m = comando.ExecuteReader();

                int r = 0;
                while (m.Read())
                {
                    r = (int)m["return_value"];

                }

                return r;
            }

        }
    }
}