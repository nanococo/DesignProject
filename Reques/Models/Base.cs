using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Reques.Models {
    public class Base {

        readonly string connectionString = "Server=192.168.39.199;Database=Reques;User Id=waifuBot;Password=pass1234;";

        public int signUp(string name, string lastname, string email, string password) {
            using (SqlConnection con = new SqlConnection(connectionString)) {
                using (SqlCommand cmd = new SqlCommand("sp_insertUser", con)) {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                    cmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = lastname;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;

                    var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    var result = returnParameter.Value;
                    con.Close();
                    return (int)result;               }
            }
        }

        public List<ArrayList> getAllUsers() {

            List<ArrayList> users = new List<ArrayList>();
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                conn.Open();

                SqlCommand comando = new SqlCommand("Exec sp_getAllUsers", conn);

                SqlDataReader m = comando.ExecuteReader();

                String nombre = "";
                int id = 0;
                while (m.Read()) {

                    nombre = (String)m["Name"];
                    id = (int)m["ID"];

                    var user = new ArrayList() { nombre, id };
                    users.Add(user);
                }
            }
            return users;
        }

        public List<ArrayList> getAllProjects() {
            List<ArrayList> projects = new List<ArrayList>();

            using (SqlConnection conn = new SqlConnection(connectionString)) {
                conn.Open();

                SqlCommand comando = new SqlCommand("Exec sp_getAllProjects", conn);

                SqlDataReader m = comando.ExecuteReader();

                String nombre = "";
                int id = 0;
                while (m.Read()) {

                    nombre = (String)m["Name"];
                    id = (int)m["ID"];

                    var project = new ArrayList() { nombre, id };
                    projects.Add(project);
                }
            }

            return projects;

        }

        public List<ArrayList> getAllRequirements() {
            List<ArrayList> requirements = new List<ArrayList>();

            using (SqlConnection conn = new SqlConnection(connectionString)) {
                conn.Open();

                SqlCommand comando = new SqlCommand("Exec sp_getAllRequirements", conn);

                SqlDataReader m = comando.ExecuteReader();

                String nombre = "";
                int id = 0;
                while (m.Read()) {

                    nombre = (String)m["Name"];
                    id = (int)m["ID"];

                    var requirement = new ArrayList() { nombre, id };
                    requirements.Add(requirement);
                }
            }
            return requirements;
        }

        public int signIn(string email, string password) {
            using (SqlConnection con = new SqlConnection(connectionString)) {
                using (SqlCommand cmd = new SqlCommand("sp_signIN", con)) {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = email;
                    cmd.Parameters.Add("@Contra", SqlDbType.VarChar).Value = password;

                    var returnParameter = cmd.Parameters.Add("@Respuesta", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    var result = returnParameter.Value;
                    con.Close();
                    return (int)result;
                }
            }
        }

        internal int insertRequirement(string name, string description, string correoN, string radio, string projectId, string assignee) {
            using (SqlConnection con = new SqlConnection(connectionString)) {
                using (SqlCommand cmd = new SqlCommand("sp_insertRequirement", con)) {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                    cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = description;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = correoN;
                    cmd.Parameters.Add("@requirementType", SqlDbType.Int).Value = Int32.Parse(radio);
                    cmd.Parameters.Add("@projectId", SqlDbType.Int).Value = Int32.Parse(projectId);
                    cmd.Parameters.Add("@assigneeId", SqlDbType.Int).Value = Int32.Parse(assignee);

                    var returnParameter = cmd.Parameters.Add("@Return_Status", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    var result = returnParameter.Value;
                    con.Close();
                    return (int) result;
                }
            }
        }

        internal int insertActivity(string name, string description, string correoN, string asssigneeId, string requirementId) {
            using (SqlConnection con = new SqlConnection(connectionString)) {
                using (SqlCommand cmd = new SqlCommand("sp_insertActivity", con)) {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                    cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = description;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = correoN;
                    cmd.Parameters.Add("@assigneeId", SqlDbType.Int).Value = Int32.Parse(asssigneeId);
                    cmd.Parameters.Add("@requirementId", SqlDbType.Int).Value = Int32.Parse(requirementId);

                    var returnParameter = cmd.Parameters.Add("@Return_Status", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    var result = returnParameter.Value;
                    con.Close();
                    return (int)result;
                }
            }
        }

        internal int insertProject(string name, string description) {
            using (SqlConnection con = new SqlConnection(connectionString)) {
                using (SqlCommand cmd = new SqlCommand("sp_insertProject", con)) {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                    cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = description;

                    var returnParameter = cmd.Parameters.Add("@Return_Status", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    var result = returnParameter.Value;
                    con.Close();
                    return (int)result;
                }
            }
        }


    }
}