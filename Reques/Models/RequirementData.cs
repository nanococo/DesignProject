using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Reques.Models {
    public class RequirementData {
        public int ProjectId { get; set; }

        public List<ArrayList> requerimientosDev = new List<ArrayList>();

        public RequirementData(int id) {
            this.ProjectId = id;
            buscarRequerimientosEnDev();
        }

        public void buscarRequerimientosEnDev() {
            using (SqlConnection conn = new SqlConnection("Server=192.168.39.199;Database=Reques;User Id=waifuBot;Password=pass1234;")) {
                conn.Open();

                SqlCommand comando = new SqlCommand("Exec Requerimientos_Proyecto " + ProjectId + ", 1", conn);

                SqlDataReader m = comando.ExecuteReader();

                String pnombre = "";
                String nombre = "";
                int id = 0;
                int contador = 4;
                while (m.Read() && contador > 0) {

                    pnombre = (String)m["PNombre"];
                    nombre = (String)m["Nombre"];
                    id = (int)m["ID"];

                    var requerimiento = new ArrayList() { pnombre, nombre, id };
                    requerimientosDev.Add(requerimiento);

                    contador--;
                }

                //contador = 3;
                //comando = new SqlCommand("Exec Proyectos_Usuario '" + correo + "'", conn);

            }

        }

    }
}