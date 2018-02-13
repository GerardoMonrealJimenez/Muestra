using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssistanceOnlineWeb.Controllers
{
    /// <summary>
    /// Modelo para hacer login
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Correo electrónico
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Contraseña
        /// </summary>
        public string Password { get; set; }
    }
}