using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Reques.Models
{
    public class Base
    {
        readonly string connectionString = "Server=192.168.39.199;Database=DesignBase;User Id=waifuBot;Password=pass1234;";


        public int signUp(string name, string lastName, string email, string password) {

            using (SqlConnection conn = new SqlConnection(connectionString)) {
                using (SqlCommand cmd = new SqlCommand("sp_insertUser", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                    cmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = lastName;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;

                    var returnParameter = cmd.Parameters.Add("@Return_Status", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    var result = returnParameter.Value;
                    conn.Close();

                    return (int) result;
                }
            }
        }




        public int RegistrarUsuario(String nombre, String apellido, String correo, String contra)
        {
            using (SqlConnection conn = new SqlConnection(connectionString)) 
            {
                conn.Open();
                SqlCommand comando = new SqlCommand("Exec Inserta_Usuarios '" + nombre + "', '" + apellido + "', '" + correo + "', '" + contra + "'", conn);

                SqlDataReader m = comando.ExecuteReader();

                int r = 0;
                while (m.Read())
                {
                    r = (int)m["return_value"];
                   
                }

                conn.Close();
                return r;
            }

        }

        public int BuscarUsuario(String correo, String contra)
        {
            using (SqlConnection conn = new SqlConnection(connectionString)) 
            {
                conn.Open();
                SqlCommand comando = new SqlCommand("Exec Busca_Usuarios '" + correo + "', '" + contra + "'", conn);

                SqlDataReader m = comando.ExecuteReader();

                int r = 0;
                while (m.Read())
                {
                    r = (int)m["return_value"];

                }

                conn.Close();
                return r;
            }

        }

        public void registrarUsuarioActividad(int correoN, int x) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                conn.Open();
                SqlCommand comando = new SqlCommand("Exec Inserta_Usuarios_X_Actividad " + correoN + ", " + x , conn);

                SqlDataReader m = comando.ExecuteReader();
                conn.Close();
            }
        }

        public void RegistrarProyecto(String name, String description) {
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

            using (SqlConnection conn = new SqlConnection(connectionString)) {

                conn.Open();
                SqlCommand comando = new SqlCommand("Exec Inserta_Proyecto '" + 1 + "', '" + name + "', '" + description + "', '" + sqlFormattedDate + "'", conn);

                SqlDataReader m = comando.ExecuteReader();

                conn.Close();
            }

            
        }

        public int getLatProjectId() {
            using (SqlConnection conn = new SqlConnection(connectionString)) {


                conn.Open();
                SqlCommand comando = new SqlCommand("Exec Ultimo_Proyecto", conn);

                SqlDataReader m = comando.ExecuteReader();

                int r = 0;
                while (m.Read()) {
                    r = (int)m["ID"];

                }

                conn.Close();
                return r;
            }
        }

        public void Inserta_Proyectos_X_Usuarios(String mail, int projectId) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {


                conn.Open();
                SqlCommand comando = new SqlCommand("Exec Inserta_Proyectos_X_Usuarios '" + mail + "', " + projectId + ", 2", conn);

                SqlDataReader m = comando.ExecuteReader();
                conn.Close();
            }
        }

        public void RegistrarRequerimiento(String name, String description, String radio, String projectId) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {


                conn.Open();
                SqlCommand comando = new SqlCommand("Exec Inserta_Requerimiento 1, " + projectId + ", " + radio + ", '"+name+"', '"+description+"'", conn);

                SqlDataReader m = comando.ExecuteReader();
                conn.Close();
            }
        }

        public void RegistrarActividad(String name, String description, String prority, String requirementId) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

                conn.Open();
                SqlCommand comando = new SqlCommand("Exec Inserta_Actividades 1, " + requirementId + ", " + prority + ", '" + name + "', '" + description + "', '"+ sqlFormattedDate+"'", conn);

                SqlDataReader m = comando.ExecuteReader();
                conn.Close();
            }
        }

        public int ultimaActividad() {
            using (SqlConnection conn = new SqlConnection(connectionString)) {


                conn.Open();
                SqlCommand comando = new SqlCommand("Exec Ultima_Actividad", conn);

                SqlDataReader m = comando.ExecuteReader();

                int r = 0;
                while (m.Read()) {
                    r = (int)m["ID"];

                }

                conn.Close();
                return r;
            }
        }

        public int getUserId(String mail, int projectId) {
            using (SqlConnection conn = new SqlConnection(connectionString)) {


                conn.Open();
                SqlCommand comando = new SqlCommand("Exec Obtiene_ID '"+mail+"', "+projectId, conn);

                SqlDataReader m = comando.ExecuteReader();

                int r = 0;
                while (m.Read()) {
                    r = (int)m["ID"];

                }

                conn.Close();
                return r;
            }
        }



    }
}