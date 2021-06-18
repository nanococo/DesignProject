using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reques.Models {
    public class LoginModel {

        public int justSignedUp { get; set; }

        public LoginModel(int justSignedUp) {
            this.justSignedUp = justSignedUp;
        }
    }
}