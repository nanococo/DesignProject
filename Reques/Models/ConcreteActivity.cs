using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Reques.Models {

    public class ConcreteActivity {

        public int activityId { get; set; }

        public ConcreteActivity(int activityId) {
            this.activityId = activityId;
            getActivity();
        }

        public List<ArrayList> actividad = new List<ArrayList>();


        public void getActivity() {
            using (SqlConnection conn = new SqlConnection("Server=192.168.39.199;Database=Reques;User Id=waifuBot;Password=pass1234;")) {
                conn.Open();

                SqlCommand comando = new SqlCommand("Exec Busca_Actividades " + activityId, conn);

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
                    actividad.Add(requerimientoD);

                    contador--;
                }
            }
        }
    }
}