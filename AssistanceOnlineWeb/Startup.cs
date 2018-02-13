using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Cookies;
using AssistanceOnlineIdentity;
using Microsoft.Owin.Security.Google;
using AssistanceOnlineDAL;
using AssistanceOnlineDAL.Enums;
using Microsoft.Owin.Security;

[assembly: OwinStartup(typeof(AssistanceOnlineWeb.Startup))]

namespace AssistanceOnlineWeb
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Inicializamos el contexto con la cadena de conección
            const string connectionString = @"Data Source=184.168.194.62;Initial Catalog=AssistanceOnline;Persist Security Info=True;User ID=AssistanceOnlineUser;Password=Gunq45@5;";

            app.CreatePerOwinContext(() => new IdentityDbContext(connectionString));
            //Implementacion de userStore
            app.CreatePerOwinContext<UserStore<IdentityUser>>(
                                                                (opt, cont) => new UserStore<IdentityUser>(cont.Get<IdentityDbContext>())
                                                              );

            //Implementacion de userManager
            app.CreatePerOwinContext<UserManager<IdentityUser>>(
                                                                  (opt, cont) =>
                                                                  {
                                                                      var userManager = new UserManager<IdentityUser>(cont.Get<UserStore<IdentityUser>>());

                                                                      userManager.UserTokenProvider = new DataProtectorTokenProvider<IdentityUser>(opt.DataProtectionProvider.Create());

                                                                      userManager.EmailService = new EmailService();

                                                                      userManager.UserValidator = new UserValidator<IdentityUser>(userManager) { RequireUniqueEmail = true, AllowOnlyAlphanumericUserNames = true };

                                                                      userManager.PasswordValidator = new PasswordValidator
                                                                      {
                                                                          RequiredLength = 8
                                                                      };

                                                                      userManager.UserLockoutEnabledByDefault = true;

                                                                      userManager.MaxFailedAccessAttemptsBeforeLockout = 10;

                                                                      userManager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(1);

                                                                      return userManager;
                                                                  } 
                                                                );
            //Implementación SignIn
            app.CreatePerOwinContext<SignInManager<IdentityUser, string>>((opt, cont) => new SignInManager<IdentityUser, string>(cont.Get<UserManager<IdentityUser>>(), cont.Authentication));

            // Cookies Authentication

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });

            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(3));

            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            //Implementación de autenticación con google
            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions
                {
                    ClientId = AssistanceOnlineQueries.selectKey(TypesKeys.ClientIdGoogle).Response.value,
                    ClientSecret = AssistanceOnlineQueries.selectKey(TypesKeys.ClientSecretGoogle).Response.value,
                    Caption = "Google"
                }
            );
        }
    }
}
