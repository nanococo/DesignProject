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
            var db = new Base();
            requerimiento = db.getRequirementById(requirementId);
            actividades = db.getRequirementActivities(requirementId);
        }
    }
}