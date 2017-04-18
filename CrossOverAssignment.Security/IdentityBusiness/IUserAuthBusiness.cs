using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CrossOverAssignment.Security.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace CrossOverAssignment.Security.IdentityBusiness
{
    public interface IUserAuthBusiness
    {
        Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout);

        Task<bool> HasBeenVerifiedAsync();

        Task<SignInStatus> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberBrowser);

        Task<IdentityResult> CreateAsync(UserInformation user);

        Task SignInAsync(UserInformation user, bool isPersistent, bool rememberBrowser);

        Task<IdentityResult> ConfirmEmailAsync(string userId, string token);

        UserInformation FindByNameAsync(string userName);

        Task<bool> IsEmailConfirmedAsync(string userId);

        Task<IdentityResult> ResetPasswordAsync(string userId, string token, string newPassword);

        Task<string> GetVerifiedUserIdAsync();

        Task<IList<string>> GetValidTwoFactorProvidersAsync(string userId);

        Task<bool> SendTwoFactorCodeAsync(string provider);

        Task<SignInStatus> ExternalSignInAsync(ExternalLoginInfo exerExternalLoginInfo, bool isPersistent);

        Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo userLoginInfo);
    }
}
