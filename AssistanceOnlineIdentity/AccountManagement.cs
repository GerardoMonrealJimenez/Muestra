using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistanceOnlineIdentity
{
    public  class AccountManagement
    {
        public UserManager<IdentityUser> UserManager { get; }

        public SignInManager<IdentityUser, string> SignInManager { get; }

        public AccountManagement(UserManager<IdentityUser> UserManager, SignInManager<IdentityUser, string> SignInManager)
        {
            this.UserManager = UserManager;

            this.SignInManager = SignInManager;
        }

        /// <summary>
        /// Busca al usuario por email
        /// </summary>
        /// <param name="email">correo</param>
        /// <returns></returns>
        public async Task<IdentityUser> encontrarUsuarioPorEmail(string email)
        {
            try
            {
                return await UserManager.FindByEmailAsync(email);

              
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Crea un nuevo Usuario
        /// </summary>
        /// <param name="name">Nombre</param>
        /// <param name="email">Correo</param>
        /// <param name="password">Contraseña</param>
        /// <returns></returns>
        public async Task<IdentityResult> crearUsuarioAsync(string name ,string email, string password)
        {
            try
            {
                var user = new IdentityUser(name) { Email = email, UserName = name };

                return await UserManager.CreateAsync(user, password);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Crea usuarios que se registran con otros providers
        /// </summary>
        /// <param name="name">Nombre</param>
        /// <param name="email">Correo</param>
        /// <returns></returns>
        public async Task<IdentityResult> crearUsuarioExterno(string name, string email)
        {
            try
            {
                var user = new IdentityUser(name) { Email = email, UserName = name };
                return await UserManager.CreateAsync(user);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Genera token de confirmación
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public async Task<string> generarTokenEmailConfirmacion(string idUser)
        {
            try
            {
                return await UserManager.GenerateEmailConfirmationTokenAsync(idUser);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Confirmacion de cuenta via email
        /// </summary>
        /// <param name="userid">Id del usuario</param>
        /// <param name="token">Token</param>
        /// <returns></returns>
        public async Task<IdentityResult> confirmEmail(string userid, string token)
        {
            return await UserManager.ConfirmEmailAsync(userid, token);
        }

        /// <summary>
        /// Genera token para restaurar la contraseña
        /// </summary>
        /// <param name="userid">Id del usuario</param>
        /// <returns></returns>
        public async Task<string> passwordResetToken(string userid)
        {
            try
            {
                return await UserManager.GeneratePasswordResetTokenAsync(userid);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Hace el reset del password del ususario
        /// </summary>
        /// <param name="userid">Id usuario</param>
        /// <param name="token">Token</param>
        /// <param name="newPassword">Nuevo password</param>
        /// <returns></returns>
        public async Task<IdentityResult> PasswordReset(string userid, string token, string newPassword)
        {
            return await UserManager.ResetPasswordAsync(userid, token, newPassword);
        }

        /// <summary>
        /// Obtiene la infromacion del login de provedores externos
        /// </summary>
        /// <returns></returns>
        public async Task<ExternalLoginInfo> getExternalLoginInfo()
        {
            return await SignInManager.AuthenticationManager.GetExternalLoginInfoAsync();
        }

        /// <summary>
        /// Obtiene el estatus del sigIn externo
        /// </summary>
        /// <returns></returns>
        public async Task<SignInStatus> getSigInStatus()
        {
            return await SignInManager.ExternalSignInAsync(await getExternalLoginInfo(), true);
        }

        /// <summary>
        /// Genera Un login
        /// </summary>
        /// <param name="userid">Id del usuario</param>
        /// <param name="login">Información del login</param>
        /// <returns></returns>
        public async Task<IdentityResult> AddLogin(string userid, UserLoginInfo login)
        {
            return await UserManager.AddLoginAsync(userid, login);
        }

        public async Task<SignInStatus> PasswordSignInAsync(IdentityUser user, string password)
        {
            return await SignInManager.PasswordSignInAsync(user.UserName, password,true,true);
        }

        /// <summary>
        /// Verifica que la contraseña sea correcta
        /// </summary>
        /// <param name="email">Correo</param>
        /// <param name="password">Contraseña</param>
        /// <returns></returns>
        public async Task<bool> CheckPasswordAsync(string email, string password)
        {
            return await UserManager.CheckPasswordAsync(new IdentityUser { Email = email }, UserManager.PasswordHasher.HashPassword(password));
        }

    }
}
