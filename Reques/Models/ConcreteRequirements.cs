using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Reques.Models {
    public class ConcreteRequirements {

        public int requirementId { get; set; }

        public List<ArrayList> requerimiento = new List<ArrayList>();
        public List<ArrayList> actividades = new List<ArrayList>();

        public ConcreteRequirements(int requirementId) {
            this.requirementId = requirementId;
            buscarDataDeRequerimiento();
            //buscarActividades();
        }

        public void buscarDataDeRequerimiento() {
            using (SqlConnection conn = new SqlConnection("Server=192.168.39.199;Database=Reques;User Id=waifuBot;Password=pass1234;")) {
                conn.Open();

                SqlCommand comando = new SqlCommand("Exec Busca_Requerimiento " + requirementId, conn);

                SqlDataReader m = comando.ExecuteReader();

                String nombre = "";
                String description = "";
                int id = 0;
                int contador = 4;
                while (m.Read() && contador > 0) {

                    nombre = (String)m["Nombre"];
                    description = (String)m["Descripcion"];
                    id = (int)m["ID"];

                    var requerimientoD = new ArrayList() { nombre, description, id };
                    requerimiento.Add(requerimientoD);

                    contador--;
                }
            }
        }
    }
}