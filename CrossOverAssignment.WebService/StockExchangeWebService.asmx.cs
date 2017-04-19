using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
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
        public Dictionary<string, double> ExposeStockPrice(IList<string> listOfStockCode)
        {
            if (Auth != null && (Auth != null || Auth.IsValid()))
            {
                var result = new Dictionary<string, double>();

                if (listOfStockCode == null || listOfStockCode.Count == 0)
                {
                    return result;
                }

                Random randomPrice = new Random();

                foreach (var stockCode in listOfStockCode)
                {
                    result.Add(stockCode, randomPrice.Next(1, 1000));
                }

                return result;
            }

            throw new AuthenticationException("Error in authentication");
        }
    }
}
