using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using CrossOverAssignment.WebService.Security;

namespace CrossOverAssignment.WebService
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class StockExchangeWebService : System.Web.Services.WebService
    {

        public UserAuth Auth;

        [WebMethod]
        [SoapHeader("Auth", Required = true)]
        public string HelloWorld(string userName)
        {
            if (Auth != null)
            {
                if (Auth.IsValid())
                {
                    return string.Format("Hello...{0} {1} ☺ ", userName,
                       DateTime.Now.ToString("tt") == "AM" ? " good morning " : " good evening ");
                }
                   

                return "Error in authentication";
            }
            else
            {
                return "Error in authentication";
            }
        }
    }
}
