using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Reques.Models {

    public class ConcreteActivity {

        public int activityId { get; set; }

        public List<ArrayList> actividad = new List<ArrayList>();


        public ConcreteActivity(int activityId) {
            this.activityId = activityId;
            actividad = new Base().getActivity(activityId);
        }


    }
}