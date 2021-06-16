﻿using System;
using System.Collections.Generic;
using System.Data;
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
            using (SqlConnection conn = new SqlConnection("Server=192.168.39.199;Database=Reques;User Id=waifuBot;Password=pass1234;"))
            //using (conn = new SqlConnection("Server=LAPTOP-B9MVKMJ5;Database=Reques;User Id=Usuario;Password=1324;"))
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
            using (SqlConnection conn = new SqlConnection("Server=192.168.39.199;Database=Reques;User Id=waifuBot;Password=pass1234;")) 
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
            using (SqlConnection conn = new SqlConnection("Server=192.168.39.199;Database=Reques;User Id=waifuBot;Password=pass1234;")) 
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
            using (SqlConnection conn = new SqlConnection("Server=192.168.39.199;Database=Reques;User Id=waifuBot;Password=pass1234;")) {
                conn.Open();
                SqlCommand comando = new SqlCommand("Exec Inserta_Usuarios_X_Actividad " + correoN + ", " + x , conn);

                SqlDataReader m = comando.ExecuteReader();
                conn.Close();
            }
        }

        public void RegistrarProyecto(String name, String description) {
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

            using (SqlConnection conn = new SqlConnection("Server=192.168.39.199;Database=Reques;User Id=waifuBot;Password=pass1234;")) {

                conn.Open();
                SqlCommand comando = new SqlCommand("Exec Inserta_Proyecto '" + 1 + "', '" + name + "', '" + description + "', '" + sqlFormattedDate + "'", conn);

                SqlDataReader m = comando.ExecuteReader();

                conn.Close();
            }

            
        }

        public int getLatProjectId() {
            using (SqlConnection conn = new SqlConnection("Server=192.168.39.199;Database=Reques;User Id=waifuBot;Password=pass1234;")) {


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
            using (SqlConnection conn = new SqlConnection("Server=192.168.39.199;Database=Reques;User Id=waifuBot;Password=pass1234;")) {


                conn.Open();
                SqlCommand comando = new SqlCommand("Exec Inserta_Proyectos_X_Usuarios '" + mail + "', " + projectId + ", 2", conn);

                SqlDataReader m = comando.ExecuteReader();
                conn.Close();
            }
        }

        public void RegistrarRequerimiento(String name, String description, String radio, String projectId) {
            using (SqlConnection conn = new SqlConnection("Server=192.168.39.199;Database=Reques;User Id=waifuBot;Password=pass1234;")) {


                conn.Open();
                SqlCommand comando = new SqlCommand("Exec Inserta_Requerimiento 1, " + projectId + ", " + radio + ", '"+name+"', '"+description+"'", conn);

                SqlDataReader m = comando.ExecuteReader();
                conn.Close();
            }
        }

        public void RegistrarActividad(String name, String description, String prority, String requirementId) {
            using (SqlConnection conn = new SqlConnection("Server=192.168.39.199;Database=Reques;User Id=waifuBot;Password=pass1234;")) {
                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

                conn.Open();
                SqlCommand comando = new SqlCommand("Exec Inserta_Actividades 1, " + requirementId + ", " + prority + ", '" + name + "', '" + description + "', '"+ sqlFormattedDate+"'", conn);

                SqlDataReader m = comando.ExecuteReader();
                conn.Close();
            }
        }

        public int ultimaActividad() {
            using (SqlConnection conn = new SqlConnection("Server=192.168.39.199;Database=Reques;User Id=waifuBot;Password=pass1234;")) {


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
            using (SqlConnection conn = new SqlConnection("Server=192.168.39.199;Database=Reques;User Id=waifuBot;Password=pass1234;")) {


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