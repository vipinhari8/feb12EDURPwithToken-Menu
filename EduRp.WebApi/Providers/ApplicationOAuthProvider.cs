using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using EduRp.WebApi.Models;
using EduRp.Service.Service;
using EduRp.Service.IService;

namespace EduRp.WebApi.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        #region[GrantResourceOwnerCredentials]
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            return Task.Factory.StartNew(() =>
            {
                var userName = context.UserName;
                var password = context.Password;
                IUserService userService = new UserService(); // our created one
                var user = userService.ValidateUser(userName, password);
                if (user != null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Sid, Convert.ToString(user.UserId)),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Email, user.EmailAddress)
                    };
                    ClaimsIdentity oAuthIdentity = new ClaimsIdentity(claims,
                                Startup.OAuthOptions.AuthenticationType);

                    var properties = CreateProperties(user.UserName,user.UniversityId,user.UserId,user.UserRoleId);
                    var ticket = new AuthenticationTicket(oAuthIdentity, properties);
                    context.Validated(ticket);
                }
                else
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect");
                }
            });
        }
        #endregion

        #region[ValidateClientAuthentication]
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
                context.Validated();

            return Task.FromResult<object>(null);
        }
        #endregion

        #region[TokenEndpoint]
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
        #endregion

        #region[CreateProperties]
        public static AuthenticationProperties CreateProperties(string userName,int? UniversityId,int? userid,int? roleid)
        {
            IDictionary<string, string> data = new Dictionary<string, string>();
            data.Add("userName", userName);
            data.Add("UniversityId", UniversityId.ToString());
            data.Add("userid", userid.ToString());
            data.Add("roleid", roleid.ToString());
           
            return new AuthenticationProperties(data);
        }
        #endregion
    }
}