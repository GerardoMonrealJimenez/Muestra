using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssistanceOnlineWeb.Models
{
    /// <summary>
    /// Modelo para el registro de un usuario
    /// </summary>
    public class RegisterModel
    {
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string UserName { get; set; }
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