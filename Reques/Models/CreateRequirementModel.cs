using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Reques.Models {

    public class CreateRequirementModel {

        public List<ArrayList> projects = new List<ArrayList>();
        public List<ArrayList> users = new List<ArrayList>();

        public CreateRequirementModel() {
            var db = new Base();
            projects = db.getAllProjects();
            users = db.getAllUsers();
        }


    }
}