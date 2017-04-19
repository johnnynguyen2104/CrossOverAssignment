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
            //Write the logic to Check the User Details From DataBase  
            //i can chek with some hardcode details UserName=Nitin and Password=Pandit  
            return UserName == "Nitin" && Password == "Pandit";
            //it'll check the details and will return true or false   
        }
    }
}