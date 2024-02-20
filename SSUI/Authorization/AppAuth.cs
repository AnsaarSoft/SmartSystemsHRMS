using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;
using System.Security.Principal;

namespace SSUI.Authorization
{
    public class AppAuth : AuthenticationStateProvider
    {
        private readonly AuthenticationState oState;
        private readonly ILogger<AppAuth> log;
        private readonly ProtectedBrowserStorage oStorage;

        public AppAuth(ILogger<AppAuth> logger, ProtectedBrowserStorage storage)
        {
            log = logger;
            oStorage = storage;
            oState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
			try
			{
                var AccessToken = await oStorage.GetAsync<string>("accesstoken");
                var UserInfo = await oStorage.GetAsync<string>("userinfo");
                var Company = await oStorage.GetAsync<string>("company");
                if(!string.IsNullOrEmpty(AccessToken.Value))
                {
                    var IdentityUser = JwtParser.ParseClaimsFromJwt(AccessToken.Value);
                    var SuperUser = (from a in IdentityUser
                                     where a.Type.ToLower() == "SuperUser".ToLower()
                                     select a.Value).FirstOrDefault();
                    if(Convert.ToBoolean(SuperUser))
                    {
                        if(IdentityUser.Where(x=>x.Type.ToLower() == "UserCode".ToLower()).Count() > 0 )
                        {
                            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(AccessToken.Value), CookieAuthenticationDefaults.AuthenticationScheme)));
                        }
                        else
                        {
                            return oState;
                        }
                    }
                    else
                    {
                        if (IdentityUser.Count() > 0)
                        {
                            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(AccessToken.Value), CookieAuthenticationDefaults.AuthenticationScheme)));
                        }
                        else
                        {
                            //vw_UserModel user = await _userService.GetUserByUserCodeAsync(accessToken, UserCode, CompanyPin);
                            //if (user.UserCode != null)
                            //{
                            //    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(AccessToken.Value), CookieAuthenticationDefaults.AuthenticationScheme)));
                            //}
                            //else
                            //{
                            //    //await MarkUserAsLoggedOut();
                            //    return oState;
                            //}
                        }
                    }
                }
                return oState;
			}
			catch (Exception ex)
			{
                log.LogError(ex, ex.Message);
                return oState;
			}
        }
    }
}
