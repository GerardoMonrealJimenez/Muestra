using AssistanceOnlineIdentity;
using AssistanceOnlineUtilities;
using AssistanceOnlineWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AssistanceOnlineWeb.Controllers
{
    public class SignUpController : Controller
    {

        //Instancia de UserManager para los request
        public UserManager<IdentityUser> UserManager => HttpContext.GetOwinContext().Get<UserManager<IdentityUser>>();

        public SignInManager<IdentityUser, string> SignInManager => HttpContext.GetOwinContext().Get<SignInManager<IdentityUser, string>>();

        /// <summary>
        /// Regresa la vista del singUp
        /// </summary>
        /// <returns></returns>
        // GET: SignUp
        [HttpGet]
        public ActionResult Index()
        {
            if (! User.Identity.IsAuthenticated)
            {
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Verifica y registra usuarios nuevos
        /// </summary>
        /// <param name="model">Modelo de registro</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {

            var accountManager = new AccountManagement(UserManager, SignInManager);

            var user = await accountManager.encontrarUsuarioPorEmail(model.Email);

            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }


            var identityResult = await accountManager.crearUsuarioAsync(model.UserName, model.Email, model.Password);

            if (identityResult.Succeeded)
            {
                var userNew = await accountManager.encontrarUsuarioPorEmail(model.Email);

                var token = await accountManager.generarTokenEmailConfirmacion(userNew.Id);

                var confirmUrl = Url.Action("ConfirmEmail", "SignUp", new { userid = userNew.Id, token = token }, Request.Url.Scheme);

                await UtilitesEmail.sendEmailVerificationAsync(userNew.UserName, userNew.Email, confirmUrl);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", identityResult.Errors.FirstOrDefault());

            return View(model);
        }

        /// <summary>
        /// Verifica los emails de los nuevos usuarios
        /// </summary>
        /// <param name="userid">Id del usuario</param>
        /// <param name="token">Token</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> ConfirmEmail(string userid, string token)
        {
            var accountManager = new AccountManagement(UserManager, SignInManager);

            var identityResult = await accountManager.confirmEmail(userid, token);

            if (identityResult.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }
        /// <summary>
        /// Muestra la vista de ForgotPassword
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            var accountManager = new AccountManagement(UserManager, SignInManager);

            var user = await accountManager.encontrarUsuarioPorEmail(model.Email);

            if (user != null)
            {
                var token = await accountManager.passwordResetToken(user.Id);

                var url = Url.Action("PasswordReset", "SignUp", new { userid = user.Id, token = token},Request.Url.Scheme);

                await UtilitesEmail.sendEmailResetPasswordAsync(user.UserName, user.Email, url);

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }
        /// <summary>
        /// devuelve la vista para seguir com el proceso de reset de la contraseña
        /// </summary>
        /// <param name="userid">Id del usuario</param>
        /// <param name="token">Token</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PasswordReset(string userid, string token)
        {
            
            return View(new PasswordResetModel { userid = userid, token = token });
        }

        /// <summary>
        /// Se encarga de hacer el reset de la contraseña
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> PasswordReset(PasswordResetModel model)
        {
            var accountManager = new AccountManagement(UserManager, SignInManager);


            var Identityresponse = await accountManager.PasswordReset(model.userid, model.token, model.newPassword);

            if (! Identityresponse.Succeeded)
            {
                return View("Error");
            }

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Genera la autenticación externa para el proovedor indicado
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public ActionResult ExternalAuthentication(string provider)
        {
            SignInManager.AuthenticationManager.Challenge(
                new AuthenticationProperties
                {
                    RedirectUri = Url.Action("ExternalCallback",new { provider})
                },
                provider
                );
            return new HttpUnauthorizedResult();
        }

        public async Task<ActionResult> ExternalCallback(string provider)
        {
            var accountManager = new AccountManagement(UserManager, SignInManager);

            var loginInfo = await accountManager.getExternalLoginInfo();

            var sigInStatus = await accountManager.getSigInStatus();

            switch (sigInStatus)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Index", "Home");
                default:
                    var user = await accountManager.encontrarUsuarioPorEmail(loginInfo.Email);

                    if (user != null)
                    {
                        var result = await accountManager.AddLogin(user.Id, loginInfo.Login);

                        if (result.Succeeded)
                        {
                            return await ExternalCallback(provider);
                        }
                        // falta pantalla de error
                    }
                    else
                    {
                        var response = await accountManager.crearUsuarioExterno(loginInfo.DefaultUserName, loginInfo.Email);

                        if (response.Succeeded)
                        {
                            return await ExternalCallback(provider);
                        }
                    }
                    return View("Error");
            }
        }
        /// <summary>
        /// Regresa la vista del login
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
        /// <summary>
        /// Hace el login a la aplicación
        /// </summary>
        /// <param name="model">modelo del login</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Login(LoginModel model)
        {
            var accountManager = new AccountManagement(UserManager, SignInManager);

            if (await accountManager.CheckPasswordAsync(model.Email, model.Password))
            {
                var user = await accountManager.encontrarUsuarioPorEmail(model.Email);

                var response = await accountManager.PasswordSignInAsync(user, model.Password);

                switch (response)
                {
                    case SignInStatus.Success:
                        return RedirectToAction("Index", "Home");
                    case SignInStatus.LockedOut:
                        break;
                    case SignInStatus.RequiresVerification:
                        break;
                    case SignInStatus.Failure:
                        break;
                    default:
                        break;
                }
            }

            return RedirectToAction("Index", "Error");
        }
        /// <summary>
        /// Hace el logout de la aplicación
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult LogOut()
        {
            SignInManager.AuthenticationManager.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}