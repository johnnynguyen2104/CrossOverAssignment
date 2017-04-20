using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrossOverAssignment.WebService.Security
{
    public class UserAuth : System.Web.Services.Protocols.SoapHeader
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsValid()
        {
            return UserName == "CrossOver" && Password == "CrossOver"; 
        }
    }
}