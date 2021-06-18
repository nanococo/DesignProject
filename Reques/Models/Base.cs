using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Reques.Models {
    public class Base {

        readonly string connectionString = "Server=192.168.39.199;Database=DesignBase;User Id=waifuBot;Password=pass1234;";

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

        internal List<ArrayList> getActivity(int activityId) {
            List<ArrayList> reqs = new List<ArrayList>();
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                conn.Open();

                SqlCommand comando = new SqlCommand("Exec sp_getActivityByID " + activityId, conn);

                SqlDataReader m = comando.ExecuteReader();


                string nombre = "";
                string description = "";
                string req_Id = "";
                string assignee = "";
                string reporter = "";
                string state = "";


                int id = 0;
                while (m.Read()) {

                    id = (int)m["ID"];
                    nombre = (string)m["Name"];
                    description = (string)m["Description"];
                    req_Id = Convert.ToString(m["req_Id"]);
                    assignee = (string)m["AssigneeName"];
                    reporter = (string)m["ReporterName"];
                    state = (string)m["State"];

                    var req = new ArrayList() { id, nombre, description, req_Id, assignee, reporter, state };
                    reqs.Add(req);
                }
            }
            return reqs;
        }

        public List<ArrayList> getRequirementActivities(int requirementId) {
            List<ArrayList> reqs = new List<ArrayList>();
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                conn.Open();

                SqlCommand comando = new SqlCommand("Exec sp_getRequirementActivities " + requirementId, conn);

                SqlDataReader m = comando.ExecuteReader();

                String nombre = "";
                int id = 0;
                while (m.Read()) {

                    nombre = (String)m["Name"];
                    id = (int)m["ID"];

                    var req = new ArrayList() { nombre, id };
                    reqs.Add(req);
                }
            }
            return reqs;
        }

        public List<ArrayList> getRequirementById(int requirementId) {
            List<ArrayList> reqs = new List<ArrayList>();
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                conn.Open();

                SqlCommand comando = new SqlCommand("Exec sp_getRequirementByID " + requirementId, conn);

                SqlDataReader m = comando.ExecuteReader();

                
                string nombre = "";
                string description = "";
                string project_Id = "";
                string assignee = "";
                string reporter = "";
                string state = "";
                string requirementType = "";


                int id = 0;
                while (m.Read()) {
                    
                    id = (int)m["ID"];
                    nombre = (string)m["Name"];
                    description = (string)m["Description"];
                    project_Id = Convert.ToString(m["project_Id"]);
                    assignee = (string)m["AssigneeName"];
                    reporter = (string)m["ReporterName"];
                    state = (string)m["State"];
                    requirementType = (string)m["Requirement"];

                    var req = new ArrayList() { id, nombre, description, project_Id, assignee, reporter, state, requirementType };
                    reqs.Add(req);
                }
            }
            return reqs;
        }

        public List<ArrayList> getReq(int projectId, int state) {
            List<ArrayList> reqs = new List<ArrayList>();
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                conn.Open();

                SqlCommand comando = new SqlCommand("Exec sp_getProjectRequirements "+projectId+", "+state, conn);

                SqlDataReader m = comando.ExecuteReader();

                String pName = "";
                String nombre = "";
                int id = 0;
                while (m.Read()) {

                    pName = (String)m["PName"];
                    nombre = (String)m["Name"];
                    id = (int)m["ID"];

                    var req = new ArrayList() { pName, nombre, id };
                    reqs.Add(req);
                }
            }
            return reqs;
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