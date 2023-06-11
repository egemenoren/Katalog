using IdentityModel;
using IdentityServer4.Validation;
using Katalog.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Katalog.IdentityServer.Services
{
    public class IdentityResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {

        private readonly UserManager<ApplicationUser> _userManager;
        public IdentityResourceOwnerPasswordValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
    
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var existUser = await _userManager.FindByEmailAsync(context.UserName);
            if(existUser == null)
            {
                var errors = new Dictionary<string, object>();
                errors.Add("errors", new List<string> { "E-mail veya sifreniz yanlıs." });
                context.Result.CustomResponse = errors;
                return;
            }
            var pwCheck = await _userManager.CheckPasswordAsync(existUser,context.Password);
            if (!pwCheck)
            {
                var errors = new Dictionary<string, object>();
                errors.Add("errors", new List<string> { "E-mail veya sifreniz yanlıs." });
                context.Result.CustomResponse = errors;
                return;
            }
            context.Result = new GrantValidationResult(existUser.Id, OidcConstants.AuthenticationMethods.Password);
        }
    }
}
