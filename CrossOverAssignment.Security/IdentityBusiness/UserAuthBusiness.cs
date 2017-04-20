using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossOverAssignment.DAL.DomainModels;
using CrossOverAssignment.Security.Identity;
using CrossOverAssignment.Security.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace CrossOverAssignment.Security.IdentityBusiness
{
    public class UserAuthBusiness : IUserAuthBusiness
    {
        public IdentityConfig.ApplicationSignInManager SignInManager { get; set; }
        public IdentityConfig.ApplicationUserManager UserManager { get; set; }

        public UserAuthBusiness(IdentityConfig.ApplicationUserManager userManager, IdentityConfig.ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout)
        {
            var taskResult = SignInManager.PasswordSignInAsync(userName, password, isPersistent, shouldLockout);
            return taskResult;
        }

        public Task<bool> HasBeenVerifiedAsync()
        {
            var taskResult = SignInManager.HasBeenVerifiedAsync();
            return taskResult;
        }

        public Task<SignInStatus> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberBrowser)
        {
            var taskResult = SignInManager.TwoFactorSignInAsync(provider, code, isPersistent, rememberBrowser);
            return taskResult;
        }

        public Task<IdentityResult> CreateAsync(UserInformation user)
        {
            var userAuth = new User()
            {
                UserName = user.UserName,
                Email = user.Email
            };

            var result = UserManager.CreateAsync(userAuth, user.Password);

            user.Id = userAuth.Id;
            return result;
        }

        public Task SignInAsync(UserInformation user, bool isPersistent, bool rememberBrowser)
        {
            var taskResult = SignInManager.SignInAsync(new User()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
            }, isPersistent, rememberBrowser);

            return taskResult;
        }

        public Task<IdentityResult> ConfirmEmailAsync(string userId, string token)
        {
            var taskResult = UserManager.ConfirmEmailAsync(userId, token);
            return taskResult;
        }

        public  UserInformation FindByNameAsync(string userName)
        {
            var taskResult =  UserManager.FindByNameAsync(userName).Result;
            return new UserInformation()
            {
                Id = taskResult.Id,
                Password = taskResult.PasswordHash,
                Email = taskResult.Email,
                UserName = taskResult.UserName
            };
        }

        public Task<bool> IsEmailConfirmedAsync(string userId)
        {
            var taskResult = UserManager.IsEmailConfirmedAsync(userId);
            return taskResult;
        }

        public Task<IdentityResult> ResetPasswordAsync(string userId, string token, string newPassword)
        {
            var taskResult = UserManager.ResetPasswordAsync(userId, token, newPassword);
            return taskResult;
        }

        public Task<string> GetVerifiedUserIdAsync()
        {
            var taskResult = SignInManager.GetVerifiedUserIdAsync();
            return taskResult;
        }

        public Task<IList<string>> GetValidTwoFactorProvidersAsync(string userId)
        {
            var taskResult = UserManager.GetValidTwoFactorProvidersAsync(userId);
            return taskResult;
        }

        public Task<bool> SendTwoFactorCodeAsync(string provider)
        {
            var taskResult = SignInManager.SendTwoFactorCodeAsync(provider);
            return taskResult;
        }

        public Task<SignInStatus> ExternalSignInAsync(ExternalLoginInfo exerExternalLoginInfo, bool isPersistent)
        {
            var taskResult = SignInManager.ExternalSignInAsync(exerExternalLoginInfo, isPersistent);
            return taskResult;
        }

        public Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo userLoginInfo)
        {
            var taskResult = UserManager.AddLoginAsync(userId, userLoginInfo);
            return taskResult;
        }
    }
}
