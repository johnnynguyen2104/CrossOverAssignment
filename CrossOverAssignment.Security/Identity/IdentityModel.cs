using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CrossOverAssignment.DAL.DomainModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace CrossOverAssignment.Security.Identity
{
    public class ApplicationUserStore :
      UserStore<User, Role, string, UserLogin, UserRoles, UserClaim>,
     IUserStore<User>,
     IDisposable
    {
        public ApplicationUserStore(StockTickerDbContext context) : base(context) { }
    }

}
