using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using StockExchangeService.Security;

namespace StockExchangeService
{
    /// <summary>
    /// Summary description for StockExchange
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class StockExchange : System.Web.Services.WebService
    {
        public readonly UserAuth Auth = new UserAuth();
    }
}
