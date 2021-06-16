using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Reques.Models
{
    public class Base
    {

        public Base() {
            OpenSqlConnection();
        
        }

        public void OpenSqlConnection()
        {
            //"Server=LAPTOP-B9MVKMJ5,Authentication=Windows Authentication, Database=Reques"
            using (SqlConnection conn = new SqlConnection("Server=192.168.39.199;Database=Reques;User Id=waifuBot;Password=pass1234;"))
            {
                
                SqlCommand comando = new SqlCommand("Exec Inserta_Usuarios 'jocxan', '2', '2','3'", conn);

                conn.Open();
                SqlDataReader m = comando.ExecuteReader();

                
                int r = 0;
                while (m.Read())
                {
                    r = (int)m["return_value"];
                    Console.Out.WriteLine(r);
                }
            }


        }
    }
}