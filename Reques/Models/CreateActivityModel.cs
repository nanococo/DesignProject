using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reques.Models {
    public class CreateActivityModel {

        public List<ArrayList> requirements = new List<ArrayList>();
        public List<ArrayList> users = new List<ArrayList>();

        public CreateActivityModel() {
            var db = new Base();
            requirements = db.getAllRequirements();
            users = db.getAllUsers();
        }
    }
}