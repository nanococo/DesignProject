using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Reques.Models {
    public class RequirementData {
        public int ProjectId { get; set; }

        public List<ArrayList> requerimientosIni = new List<ArrayList>();
        public List<ArrayList> requerimientosDev = new List<ArrayList>();
        public List<ArrayList> requerimientosQA = new List<ArrayList>();
        public List<ArrayList> requerimientosDone = new List<ArrayList>();

        public RequirementData(int id) {
            this.ProjectId = id;
            var db = new Base();
            requerimientosIni = db.getReq(id, 1);
            requerimientosDev = db.getReq(id, 2);
            requerimientosQA = db.getReq(id, 3);
            requerimientosDone = db.getReq(id, 4);
        }

    }
}